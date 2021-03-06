﻿using System.ComponentModel.DataAnnotations;

namespace AspnetNote.MVC6.Models
{
    public class User
    {
        /// <summary>
        /// 사용자 번호
        /// </summary>
        [Key]//PK 설정
        public int UserNo { get; set; }
        /// <summary>
        /// 사용자 이름
        /// </summary>
        [Required(ErrorMessage ="사용자 이름을 입력하세요.")] // Not Null설정
        public string UserName { get; set; }
        /// <summary>
        /// 사용자 ID
        /// </summary>
        [Required(ErrorMessage = "사용자 아이디를 입력하세요.")] // Not Null설정
        public string UserId { get; set; }
        /// <summary>
        /// 사용자 PW 
        /// </summary>
        [Required(ErrorMessage = "비밀번호를 입력하세요.")] // Not Null설정
        public string UserPassword { get; set; }
    }
}
