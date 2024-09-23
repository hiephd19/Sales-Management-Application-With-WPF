using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public void CreateMember(Member newMember)
        {
            try
            {
                using var context = new Prn221FstoreContext();
                context.Members.Add(newMember);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while inserting member: " + ex.Message);
            }
        }

        public void DeleteMemberById(int id)
        {
            try
            {
                using var context = new Prn221FstoreContext();
                Member? deleteMember = context.Members.FirstOrDefault(p => p.MemberId == id) ?? throw new Exception("Member not found!");
                context.Members.Remove(deleteMember);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while deleting member: " + ex.Message);
            }
        }

        public List<Member> GetAllMember()
        {
            try
            {
                using var context = new Prn221FstoreContext();
                return context.Members.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting all member: " + ex.Message);
            }
        }

        public Member GetMemberById(int id)
        {
            try
            {
                using var context = new Prn221FstoreContext();
                Member? member = context.Members.FirstOrDefault(p => p.MemberId == id);
                return member ?? throw new Exception("Member not found!");
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching member by ID: " + ex.Message);
            }
        }

        public void UpdateMember(Member updateMember)
        {
            try
            {
                using var context = new Prn221FstoreContext();
                Member? existingMember = context.Members.FirstOrDefault(p => p.MemberId == updateMember.MemberId)
                    ?? throw new Exception("Member not found!");                
                existingMember.Email = updateMember.Email;
                existingMember.City = updateMember.City;
                existingMember.Country = updateMember.Country;
                existingMember.CompanyName = updateMember.CompanyName;
                existingMember.Password = updateMember.Password;     
                //context.Entry(existingMember).CurrentValues.SetValues(updateMember);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while updating member: " + ex.Message);
            }
        }
    }
}
