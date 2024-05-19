using AngularApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Linq.Expressions;

namespace AngularApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly dbContext _context;
        public InventoryController(dbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllPurchase")]
        public ActionResult GetAllPurchase()
        {

            try
            {
                var all = (from purchase in _context.stockPurchase
                           join product in _context.stockProducts on purchase.productId equals product.productId
                           select new
                           {
                               invoiceAmt = purchase.invoiceAmt,
                               invoiceNo = purchase.invoiceNo,
                               productId = purchase.productId,
                               purchaseDate = purchase.purchaseDate,
                               purchaseId = purchase.purchaseId,
                               quantity = purchase.quantity,
                               supplierName = purchase.supplierName,
                               productName = product.productName,


                           }).OrderByDescending(m => m.purchaseId).ToList();

                return Ok(all);

            }
            catch (Exception ex)
            {

                return NotFound();
            }
            //var all = _context.stockPurchase.ToList();
            //if (all != null) return Ok(all);
            //return Not
        }

        [HttpPost("CreateNewPurchase")]
        public ActionResult CreateNewPurchase([FromBody] stockPurchase obj)
        {
           
               
                    var isExist = _context.stockPurchase.SingleOrDefault(m => m.invoiceNo.ToLower() == obj.invoiceNo.ToLower());
                    if (isExist == null)
                    { 

                        _context.stockPurchase.Add(obj);
                        _context.SaveChanges();
                        var isStockExist = _context.stockTable.SingleOrDefault(m => m.productId == obj.productId);
                        if (isStockExist == null)
                        {
                            stockTable stock = new stockTable()
                            {
                                createdDate = DateTime.Now,
                                updatedDate = DateTime.Now,
                                productId = obj.productId,
                                quantity = obj.quantity,
                            };
                            _context.stockTable.Add(stock);
                            _context.SaveChanges();


                        }
                        else
                        {
                            isStockExist.quantity = isStockExist.quantity + obj.quantity;
                            isStockExist.updatedDate = DateTime.Now;
                            _context.SaveChanges();

                        }
                        return Ok();


                    }

                    else
                    {
                        return NotFound();

                    }

                
                


        }
        [HttpGet("GetAllSale")]
        public ActionResult GetAllSale()
        {

            try
            {
                var all = (from sale in _context.stockSales
                           join product in _context.stockProducts on sale.productId equals product.productId
                           select new
                           {
                               MobileNo = sale.MobileNo,
                               invoiceNo = sale.invoiceNo,
                               productId = sale.productId,
                               CustomerName=sale.CustomerName,
                               saledate = sale.saledate,
                               totalAmt = sale.totalAmt,
                               quantity = sale.quantity,
                               salesId = sale.salesId,
                               productName = product.productName,


                           }).OrderByDescending(m => m.salesId).ToList();

                return Ok(all);

            }
            catch (Exception ex)
            {

                return NotFound();
            }
           
        }
        [HttpPost("CreateNewSale")]
        public ActionResult CreateNewSale([FromBody] stockSale obj)
        {


            var isExist = _context.stockSales.SingleOrDefault(m => m.invoiceNo.ToLower() == obj.invoiceNo.ToLower());
            var isStockExist = _context.stockTable.SingleOrDefault(m => m.productId == obj.productId);
            if (isExist == null && isStockExist != null)
            {

                _context.stockSales.Add(obj);
                _context.SaveChanges();
                 isStockExist.quantity = isStockExist.quantity - obj.quantity; 
                isStockExist.updatedDate = DateTime.Now;
                _context.SaveChanges();
                return Ok();


            }

            else
            {
                return NotFound();

            }
        }

        [HttpGet("GetAllProducts")]
        public ActionResult GetAllProducts()
        {

            try
            {
                var all = _context.stockProducts.ToList();

                return Ok(all);

            }
            catch (Exception ex)
            {

                return NotFound();
            }

        }
        [HttpPost("CreateNewProduct")]
        public ActionResult CreateNewProduct([FromBody] stockProduct obj)
        {


            var isExist = _context.stockProducts.SingleOrDefault(m => m.productName.ToLower() == obj.productName.ToLower()); //check for product is unique
            
            if (isExist == null)
            {

                _context.stockProducts.Add(obj);
                _context.SaveChanges();
                return Ok();
               }

            else
            {
                return NotFound();

            }





        }
        [HttpGet("GetAllStock")]
        public ActionResult GetAllStock()
        {

            try
            {
                var all = (from stock in _context.stockTable
                           join product in _context.stockProducts on stock.productId equals product.productId
                           select new
                           {
                               createdDate = stock.createdDate,
                               updatedDate = stock.updatedDate,
                               productId = stock.productId,
                               quantity = stock.quantity,
                               productName = product.productName,
                               stockId=stock.stockId,
                           }).OrderByDescending(m => m.stockId).ToList(); //on last modified stock

                return Ok(all);

            }
            catch (Exception ex)
            {

                return NotFound();
            }

        }
        [HttpGet("checkStockByProductId")]
        public ActionResult checkStockByProductId(int productId)
        {

            try
            {
                var stock = _context.stockTable.SingleOrDefault(m=>m.productId == productId);
                if(stock != null&& stock.quantity != 0)
                {
                    return Ok(stock);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {

                return StatusCode(500, "An error occurred while processing your request.");
            }

        }






    }
}
