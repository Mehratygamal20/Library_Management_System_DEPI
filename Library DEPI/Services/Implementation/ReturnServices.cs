//namespace Library_DEPI.Services.Implementation
//{
//    public class ReturnServices : IReturnServices
//    {
//        private readonly AppDBContext _context;
//        public ReturnServices(AppDBContext context)
//        {
//            _context = context;
//        }

//        public bool Create(int CheckoutId, DateTime ReturnDate)
//        {
//            //fetch the checkout entity to get duedate and book details
//            var checkout = _context.Checkouts.FirstOrDefault(c => c.Id == id);
//            if (checkout == null)
//            {
//                throw new Exception("Checkout record not found");
//            }
//            //calculate Panelty Amount if the book is returned late
//            var panelty = CalculatePenalty(Checkout.DueDate, ReturnDate);
//            //create new return entity
//            var returnEntity = new Return
//            {
//                CheckoutId = CheckoutId,
//                ReturnDate = ReturnDate,
//                PenaltyAmount = PenaltyAmount
//            };
//            //Add return entry to database
//            _context.Returns.Add(returnEntity);
//            //update the book status to available
//            var book = _context.Books.FirstOrDefault(b => b.BookId == Checkout.BookId);
//            if (book != null)
//            {
//                book.IsAvailable = true;
//            }
//            //save changes in database
//            _context.SaveChanges();
//            return returnEntity;
//        }


//        public bool Delete(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public IEnumerable<Return> GetAll()
//        {
//            return _context.Returns.Include(r => r.Id).AsNoTracking().ToList();

//            throw new NotImplementedException();
//        }

//        public Return GetOne(int id)
//        {
//            if (ISExist(id))
//            {
//                return _context.Returns.FirstOrDefault(r => r.Id == id);
//                return null;
//            }
//                //throw new NotImplementedException();
//        }

//        public bool ISExist(int id)

//        {
//            if(_context.Returns.Any(r => r.Id == id))
//                return true;
//            return false;
//            //throw new NotImplementedException();
//        }
//        public decimal CalculatePenalty(DateTime DueDate, DateTime ReturnDate)

//        {
//            if (ReturnDate <= DueDate)
//            {
//                return 0;  //no penalty
//            }
//            //caculate number of days late
//            var daysLate = (ReturnDate - DueDate).Days;
//            return daysLate;
//        }

//        public bool Create(Return data)
//        {
//            throw new NotImplementedException();
//        }

//        public bool Update(int id, Return data)
//        {
//            throw new NotImplementedException();
//        }
//        //  public bool Update(int id, Return )
//        //{
//        //  throw new NotImplementedException();
//        //}
//    }

//}

















namespace Library_DEPI.Services.Implementation
{
    public class ReturnServices : IReturnServices
    {
        private readonly AppDBContext _context;

        public ReturnServices(AppDBContext context)
        {
            _context = context;
        }

        public bool Create(Return data)
        {
            // تحقق من صحة البيانات
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            // إضافة الكائن إلى قاعدة البيانات
            _context.Returns.Add(data);
            return _context.SaveChanges() > 0; // إرجاع true إذا تم حفظ التغييرات بنجاح
        }

        public bool Create(int checkoutId, DateTime returnDate)
        {
            // جلب كائن Checkout
            var checkout = _context.Checkouts.FirstOrDefault(c => c.Id == checkoutId);
            if (checkout == null)
            {
                throw new Exception("Checkout record not found");
            }

            // حساب مبلغ الغرامة إذا تم إرجاع الكتاب متأخرًا
            var penaltyAmount = CalculatePenalty(checkout.DueDate, returnDate);

            // إنشاء كائن Return جديد
            var returnEntity = new Return
            {
                CheckoutId = checkoutId,
                ReturnDate = returnDate,
                PenaltyAmount = penaltyAmount
            };

            // إضافة سجل الإرجاع إلى قاعدة البيانات
            _context.Returns.Add(returnEntity);

            // تحديث حالة الكتاب إلى متاح
            var book = _context.Books.FirstOrDefault(b => b.Id == checkout.BookID);
            if (book != null)
            {
                book.AvailabilityStatus = true;
            }

            // حفظ التغييرات في قاعدة البيانات
            return _context.SaveChanges() > 0; // إرجاع true إذا تم حفظ التغييرات بنجاح
        }

        public bool Delete(int id)
        {
            var returnEntity = _context.Returns.FirstOrDefault(r => r.Id == id);
            if (returnEntity == null)
            {
                return false; // السجل غير موجود
            }

            _context.Returns.Remove(returnEntity);
            return _context.SaveChanges() > 0; // إرجاع true إذا تم حذف السجل بنجاح
        }

        public IEnumerable<Return> GetAll()
        {
            return _context.Returns.AsNoTracking().ToList(); // إرجاع جميع سجلات الإرجاع
        }

        public Return GetOne(int id)
        {
            return _context.Returns.FirstOrDefault(r => r.Id == id); // إرجاع السجل الذي يطابق المعرف
        }

        public bool ISExist(int id)
        {
            return _context.Returns.Any(r => r.Id == id); // التحقق مما إذا كان السجل موجودًا
        }

        public decimal CalculatePenalty(DateTime dueDate, DateTime returnDate)
        {
            if (returnDate <= dueDate)
            {
                return 0; // لا توجد غرامة
            }

            // حساب عدد الأيام المتأخرة
            var daysLate = (returnDate - dueDate).Days;
            return daysLate; // إرجاع مبلغ الغرامة
        }

        public bool Update(int id, Return data)
        {
            var existingReturn = _context.Returns.FirstOrDefault(r => r.Id == id);
            if (existingReturn == null)
            {
                return false; // السجل غير موجود
            }

            // تحديث الخصائص الخاصة بالسجل
            existingReturn.ReturnDate = data.ReturnDate;
            existingReturn.PenaltyAmount = data.PenaltyAmount;
            // يمكن إضافة تحديثات أخرى حسب الحاجة

            return _context.SaveChanges() > 0; // إرجاع true إذا تم تحديث السجل بنجاح
        }
    }
}





