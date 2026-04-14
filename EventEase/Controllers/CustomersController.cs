using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventEase.Models;

namespace EventEase.Controllers
{
    //This handles all operations related to Customers
    public class CustomersController : Controller
    {
        // Database context, used to communicate with DB

        private readonly ApplicationDbContext context;

        // A constructor.
        public CustomersController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // Get customers 
        //this returns  a list of all customers 
        public async Task<IActionResult> Index()
        {
            //retrieves all customers from the database
            return View(await context.Customers.ToListAsync());
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            // Checks if Id is missing 
            if (id == null)
            {
                return NotFound();
            }
            //Retrieves customer by the ID
            var customer = await context.Customers
                .FirstOrDefaultAsync(m => m.CustomerID == id);

            //if the customerId is not found return a null
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // get customer
        public IActionResult Create()
        {
            //just returns an empty form
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]// prevents CSRF attacks 
        public async Task<IActionResult> Create([Bind("CustomerID,FirstName,Email,PhoneNumber")] Customer customer)
        {
            //Checks if the data is valid 
            if (ModelState.IsValid)
            {

                //Adds the customer to DB
                context.Add(customer);
                await context.SaveChangesAsync(); //saves the changes made
                return RedirectToAction(nameof(Index));// redirects to the list
            }
            // if the validation fails it returns the form with errors
            return View(customer);
        }

       
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            // finds the customer by ID
            var customer = await context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerID,FirstName,Email,PhoneNumber")] Customer customer)
        {
            if (id != customer.CustomerID)
            {
                return NotFound();
            }

            // Ensures the  route ID matches object ID
            if (ModelState.IsValid)
            {
                try
                {
                    // Update customer
                    context.Update(customer);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    // If the customer no longer exists 
                    if (!CustomerExists(customer.CustomerID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

       
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await context.Customers
                .FirstOrDefaultAsync(m => m.CustomerID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await context.Customers.FindAsync(id);

            // Remove if exists
            if (customer != null)
            {
                context.Customers.Remove(customer);
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //this line checks for existence 
        private bool CustomerExists(int id)
        {
            return context.Customers.Any(e => e.CustomerID == id);
        }
    }
}
