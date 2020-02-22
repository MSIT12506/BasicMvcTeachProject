using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BasicMvcTeach01.Models.Entities;

namespace BasicMvcTeach01.Models.LibraryMember
{
    public class MemberRepository
    {
        private NorthWindEntities _northWindEntities;

        public MemberRepository()
        {
            _northWindEntities = new NorthWindEntities();
        }

        public Member GetMember(string account)
        {
            // 取得北風會員帳號
            var member = _northWindEntities.Member.FirstOrDefault(p => p.Account == account);
            return member;
        }
    }
}