using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using TestKendoUI.Data;

namespace TestKendoUI.Areas.API.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using TestKendoUI.Data;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Product>("Products");
    builder.EntitySet<BillOfMaterials>("BillOfMaterials"); 
    builder.EntitySet<ProductCostHistory>("ProductCostHistory"); 
    builder.EntitySet<ProductDocument>("ProductDocument"); 
    builder.EntitySet<ProductInventory>("ProductInventory"); 
    builder.EntitySet<ProductListPriceHistory>("ProductListPriceHistory"); 
    builder.EntitySet<ProductModel>("ProductModel"); 
    builder.EntitySet<ProductProductPhoto>("ProductProductPhoto"); 
    builder.EntitySet<ProductReview>("ProductReview"); 
    builder.EntitySet<ProductSubcategory>("ProductSubcategory"); 
    builder.EntitySet<ProductVendor>("ProductVendor"); 
    builder.EntitySet<PurchaseOrderDetail>("PurchaseOrderDetail"); 
    builder.EntitySet<ShoppingCartItem>("ShoppingCartItem"); 
    builder.EntitySet<SpecialOfferProduct>("SpecialOfferProduct"); 
    builder.EntitySet<TransactionHistory>("TransactionHistory"); 
    builder.EntitySet<UnitMeasure>("UnitMeasure"); 
    builder.EntitySet<WorkOrder>("WorkOrder"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ProductsController : ODataController
    {
        private AbventureModel db = new AbventureModel();

        // GET: odata/Products
        [EnableQuery]
        public IQueryable<Product> GetProducts()
        {
            return db.Product;
        }

        // GET: odata/Products(5)
        [EnableQuery]
        public SingleResult<Product> GetProduct([FromODataUri] int key)
        {
            return SingleResult.Create(db.Product.Where(product => product.ProductID == key));
        }

        // PUT: odata/Products(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Product> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Product product = await db.Product.FindAsync(key);
            if (product == null)
            {
                return NotFound();
            }

            patch.Put(product);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(product);
        }

        // POST: odata/Products
        public async Task<IHttpActionResult> Post(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Product.Add(product);
            await db.SaveChangesAsync();

            return Created(product);
        }

        // PATCH: odata/Products(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Product> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Product product = await db.Product.FindAsync(key);
            if (product == null)
            {
                return NotFound();
            }

            patch.Patch(product);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(product);
        }

        // DELETE: odata/Products(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Product product = await db.Product.FindAsync(key);
            if (product == null)
            {
                return NotFound();
            }

            db.Product.Remove(product);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Products(5)/BillOfMaterials
        [EnableQuery]
        public IQueryable<BillOfMaterials> GetBillOfMaterials([FromODataUri] int key)
        {
            return db.Product.Where(m => m.ProductID == key).SelectMany(m => m.BillOfMaterials);
        }

        // GET: odata/Products(5)/BillOfMaterials1
        [EnableQuery]
        public IQueryable<BillOfMaterials> GetBillOfMaterials1([FromODataUri] int key)
        {
            return db.Product.Where(m => m.ProductID == key).SelectMany(m => m.BillOfMaterials1);
        }

        // GET: odata/Products(5)/ProductCostHistory
        [EnableQuery]
        public IQueryable<ProductCostHistory> GetProductCostHistory([FromODataUri] int key)
        {
            return db.Product.Where(m => m.ProductID == key).SelectMany(m => m.ProductCostHistory);
        }

        // GET: odata/Products(5)/ProductDocument
        [EnableQuery]
        public SingleResult<ProductDocument> GetProductDocument([FromODataUri] int key)
        {
            return SingleResult.Create(db.Product.Where(m => m.ProductID == key).Select(m => m.ProductDocument));
        }

        // GET: odata/Products(5)/ProductInventory
        [EnableQuery]
        public IQueryable<ProductInventory> GetProductInventory([FromODataUri] int key)
        {
            return db.Product.Where(m => m.ProductID == key).SelectMany(m => m.ProductInventory);
        }

        // GET: odata/Products(5)/ProductListPriceHistory
        [EnableQuery]
        public IQueryable<ProductListPriceHistory> GetProductListPriceHistory([FromODataUri] int key)
        {
            return db.Product.Where(m => m.ProductID == key).SelectMany(m => m.ProductListPriceHistory);
        }

        // GET: odata/Products(5)/ProductModel
        [EnableQuery]
        public SingleResult<ProductModel> GetProductModel([FromODataUri] int key)
        {
            return SingleResult.Create(db.Product.Where(m => m.ProductID == key).Select(m => m.ProductModel));
        }

        // GET: odata/Products(5)/ProductProductPhoto
        [EnableQuery]
        public IQueryable<ProductProductPhoto> GetProductProductPhoto([FromODataUri] int key)
        {
            return db.Product.Where(m => m.ProductID == key).SelectMany(m => m.ProductProductPhoto);
        }

        // GET: odata/Products(5)/ProductReview
        [EnableQuery]
        public IQueryable<ProductReview> GetProductReview([FromODataUri] int key)
        {
            return db.Product.Where(m => m.ProductID == key).SelectMany(m => m.ProductReview);
        }

        // GET: odata/Products(5)/ProductSubcategory
        [EnableQuery]
        public SingleResult<ProductSubcategory> GetProductSubcategory([FromODataUri] int key)
        {
            return SingleResult.Create(db.Product.Where(m => m.ProductID == key).Select(m => m.ProductSubcategory));
        }

        // GET: odata/Products(5)/ProductVendor
        [EnableQuery]
        public IQueryable<ProductVendor> GetProductVendor([FromODataUri] int key)
        {
            return db.Product.Where(m => m.ProductID == key).SelectMany(m => m.ProductVendor);
        }

        // GET: odata/Products(5)/PurchaseOrderDetail
        [EnableQuery]
        public IQueryable<PurchaseOrderDetail> GetPurchaseOrderDetail([FromODataUri] int key)
        {
            return db.Product.Where(m => m.ProductID == key).SelectMany(m => m.PurchaseOrderDetail);
        }

        // GET: odata/Products(5)/ShoppingCartItem
        [EnableQuery]
        public IQueryable<ShoppingCartItem> GetShoppingCartItem([FromODataUri] int key)
        {
            return db.Product.Where(m => m.ProductID == key).SelectMany(m => m.ShoppingCartItem);
        }

        // GET: odata/Products(5)/SpecialOfferProduct
        [EnableQuery]
        public IQueryable<SpecialOfferProduct> GetSpecialOfferProduct([FromODataUri] int key)
        {
            return db.Product.Where(m => m.ProductID == key).SelectMany(m => m.SpecialOfferProduct);
        }

        // GET: odata/Products(5)/TransactionHistory
        [EnableQuery]
        public IQueryable<TransactionHistory> GetTransactionHistory([FromODataUri] int key)
        {
            return db.Product.Where(m => m.ProductID == key).SelectMany(m => m.TransactionHistory);
        }

        // GET: odata/Products(5)/UnitMeasure
        [EnableQuery]
        public SingleResult<UnitMeasure> GetUnitMeasure([FromODataUri] int key)
        {
            return SingleResult.Create(db.Product.Where(m => m.ProductID == key).Select(m => m.UnitMeasure));
        }

        // GET: odata/Products(5)/UnitMeasure1
        [EnableQuery]
        public SingleResult<UnitMeasure> GetUnitMeasure1([FromODataUri] int key)
        {
            return SingleResult.Create(db.Product.Where(m => m.ProductID == key).Select(m => m.UnitMeasure1));
        }

        // GET: odata/Products(5)/WorkOrder
        [EnableQuery]
        public IQueryable<WorkOrder> GetWorkOrder([FromODataUri] int key)
        {
            return db.Product.Where(m => m.ProductID == key).SelectMany(m => m.WorkOrder);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int key)
        {
            return db.Product.Count(e => e.ProductID == key) > 0;
        }
    }
}
