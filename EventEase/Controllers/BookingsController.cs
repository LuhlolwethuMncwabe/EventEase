using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;// this is used for dropdown lists in views
using Microsoft.EntityFrameworkCore;// This is used for database operations (EF Core)
using EventEase.Models;

namespace EventEase.Controllers
{
    // This controller handles all HTTP requests that are related to Bookings
    public class BookingsController : Controller
    {
        // A Database context that is used to interact with the database
        private readonly ApplicationDbContext _context;

         //  A Constructor, a Dependency Injection is used to pass the database context
        public BookingsController(ApplicationDbContext context)
        {
            _context = context;
        }

    
        // These lines of code retrieve bookings with relevant customer and event data
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Bookings.Include(b => b.Customer).Include(b => b.Event);
            return View(await applicationDbContext.ToListAsync());// Converts the query to a list and then passes it to the view
        }

       
       // This  displays details for a specific booking 
        public async Task<IActionResult> Details(int? id)
        {
            // Checks if the id is null
            if (id == null)
            {
                return NotFound();
            }

            //Retrieves the booking with related customer and Event
            var booking = await _context.Bookings
                .Include(b => b.Customer)
                .Include(b => b.Event)
                .FirstOrDefaultAsync(m => m.BookingID == id);
            if (booking == null)// if there is no booking found it returns a null
            {
                return NotFound();
            }
            //Passes the booking data to the view
            return View(booking); 
        }

        // This displays the form to create a new booking
        public IActionResult Create()
        {
            //this line populates the dropdown list for customers
            ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "Email");

            //This line populates the dropdown list for events 
            ViewData["EventID"] = new SelectList(_context.Events, "EventID", "EventID");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]// this protects against CSRF attacks
        public async Task<IActionResult> Create([Bind("BookingID,Status,TotalAmount,NumberOfSeats,BookedAt,EventID,CustomerID")] Booking booking)
        {


            // checks if the submitted data passes the validation rules
            if (ModelState.IsValid)
            {

                //Add the new booking to the database
                _context.Add(booking);

                //Saves changes independently 
                await _context.SaveChangesAsync();

                //Redirects to the Infdex page after a sucessful creation 
                return RedirectToAction(nameof(Index));
            }
            // If the validation fails it populates the dropdowns again and return view with data
            ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "Email", booking.CustomerID);
            ViewData["EventID"] = new SelectList(_context.Events, "EventID", "EventID", booking.EventID);

            return View(booking);
        }

        // Displays the form to edit an already existing Booking
        public async Task<IActionResult> Edit(int? id)
        {
            // Validate ID
            if (id == null)
            {
                return NotFound();
            }
            //Finds the booking id
            //If the booking is not found it returns a null
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            //this populates the dropdowns with current selection
            ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "Email", booking.CustomerID);
            ViewData["EventID"] = new SelectList(_context.Events, "EventID", "EventID", booking.EventID);
            return View(booking);
        }

        
   
        
        //Hnadles submission of edited booking  data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingID,Status,TotalAmount,NumberOfSeats,BookedAt,EventID,CustomerID")] Booking booking)
        {
            //Ensure the id in the URL matches the booking ID
            if (id != booking.BookingID)
            {
                return NotFound();
            }
            //Check if the model is valid
            if (ModelState.IsValid)
            {
                try
                {
                    // Updates the booking in the database
                    _context.Update(booking);

                    // saves changes
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //handles case where booking no longer exists
                    if (!BookingExists(booking.BookingID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;// this throws the exception again if thers another issue
                    }
                }
                //redirect after a successful update
                return RedirectToAction(nameof(Index));
            }
            //if the validation fails it reloads dropdowns and returns view
            ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "Email", booking.CustomerID);
            ViewData["EventID"] = new SelectList(_context.Events, "EventID", "EventID", booking.EventID);
            return View(booking);
        }

        
        //displays confimation page before deleting a booking
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            // Retrieves booking with data that is related 
            var booking = await _context.Bookings
                .Include(b => b.Customer)
                .Include(b => b.Event)
                .FirstOrDefaultAsync(m => m.BookingID == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

       
        //This confirms and  executes the deletation 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // find booking by ID
            var booking = await _context.Bookings.FindAsync(id);
            // if found remove it 
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
            }
            // This saves changes
            await _context.SaveChangesAsync();

            //This redirects to the list after deletation
            return RedirectToAction(nameof(Index));
        }
        //A helper method
        // Checks if a booking exists in the database
        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.BookingID == id);
        }
    }
}
