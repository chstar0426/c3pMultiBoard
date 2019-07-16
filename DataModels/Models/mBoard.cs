using System;
using System.ComponentModel.DataAnnotations;

namespace DataModels
{
    public enum Category {
        공지, QnA, 사진, 복합
    }

    public enum Encoding
    {
        HTML, TEXT, MIX
    }

    public class mBoard
    {
        public int ID { get; set; }

        /// <summary>
        /// 기본 속성
        /// </summary>
        [Display(Name = "작성자")]
        [StringLength(30)]
        [Required]
        public string Name { get; set; }

        [StringLength(30)]
        [Required]
        public string WriterID { get; set; }

        [StringLength(30)]
        [Required]
        public string Password { get; set; }

        [Display(Name = "제목")]
        [StringLength(255)]
        [Required]
        public string Title { get; set; }

        [Display(Name = "내용")]
        public string Content { get; set; }

        [Display(Name = "분류")]
        public Category Category { get; set; }

        [Display(Name = "작성일")]
        [DisplayFormat(DataFormatString ="{0:MM-dd}")]
        [DataType(DataType.DateTime)]
        public DateTime PosteDate { get; set; }

        [StringLength(30)]
        public string PostIp { get; set; }

        /// <summary>
        /// 추가속성
        /// </summary>
        [Display(Name = "열람횟수")]
        public int ReadCount { get; set; }

        [Display(Name = "하위답변갯수")]
        public int ReplySubCount { get; set; }

        [Display(Name = "인코딩")]
        public Encoding Encoing { get; set; }


        [Display(Name = "수정일")]
        [DisplayFormat(DataFormatString = "MM-dd")]
        [DataType(DataType.DateTime)]
        public DateTime? ModifyDate { get; set; }

        [StringLength(30)]
        public string ModifyIp { get; set; }

        /// <summary>
        /// 계층형 속성
        /// </summary>
        public int Ref { get; set; }
        public int Step { get; set; }
        public int RefOrder { get; set; }
        public bool DelFlag { get; set; }

    }
}
