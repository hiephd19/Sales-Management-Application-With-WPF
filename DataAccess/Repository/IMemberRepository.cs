using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {        
        public List<Member> GetAllMember();
        public Member GetMemberById(int id);
        public void DeleteMemberById(int id);
        public void CreateMember(Member newMember);
        public void UpdateMember(Member updateMember);           
    }
}
