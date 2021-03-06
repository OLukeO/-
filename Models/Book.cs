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
    using System.ComponentModel.DataAnnotations;
    
    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /*public Book()
        {
            this.book_reserve = new HashSet<book_reserve>();
        }*/
    
        public int book_ID { get; set; }
        [Display(Name = "書名")]
        public string book_name { get; set; }
        [Display(Name = "ISBN")]
        public string ISBN { get; set; }
        [Display(Name = "作者")]
        public string author { get; set; }
        [Display(Name = "出版社")]
        public string publicsh { get; set; }
        public Nullable<int> book_borrow_ID { get; set; }
        public Nullable<int> user_ID { get; set; }
        public Nullable<int> state { get; set; }
    
        public virtual User User { get; set; }
        public virtual book_reserve book_reserve { get; set; }
        public virtual book_borrow book_borrow { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<book_reserve> book_reserve { get; set; }
        public virtual User User1 { get; set; }
        public virtual User User2 { get; set; }
    }
}
