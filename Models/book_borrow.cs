//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace 實驗室管理.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class book_borrow
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public book_borrow()
        {
            this.Books = new HashSet<Book>();
            this.book_overdue = new HashSet<book_overdue>();
        }
    
        public int book_borrow_ID { get; set; }
        public System.DateTime book_borrow_sart_time { get; set; }
        public System.DateTime book_borrow_estionate_end_time { get; set; }
        public System.DateTime book_borrow_actual_ent_time { get; set; }
        public int state { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Book> Books { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<book_overdue> book_overdue { get; set; }
    }
}