using BO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    static class DeepCopyUtilities
    {
        public static void UserDOtoBO(User newuser,DO.User olduser)
        {
            newuser.Admin = olduser.admin;
            newuser.Password = olduser.password;
            newuser.UserName = olduser.userName;
            //return newuser;
        }
        public  static void LineDoToBo(Line New, DO.Line Old)
        {
            New.Id = Old.Id;
            New.FirstStation = Old.FirstStation;
            New.LastStation = Old.LastStation;
            New.Areas = (Area)Old.Areas;
            New.Code = Old.busLineNumber;
        }
        public  static void LineStationDoToBo(LineStation New, DO.LineStation Old)
        {
            New.LineId = Old.LineId;
            New.LineStationIndex = Old.LineStationIndex;
            New.NextStation = Old.NextStation;
            New.PrevStation = Old.PrevStation;
        }
        public static void BusDoToBo(Bus New, DO.Bus Old)
            {
                New.LicenseNum = Old.LicenseNum;
                New.TotalTrip = Old.TotalTrip;
                New.BusStatus = (Status)Old.BusStatus;
                New.FromDate = Old.FromDate;
                New.FuelRemain = Old.FuelRemain;

            }

        public static void CopyPropertiesTo<T, S>(this S from, T to)
        {
            foreach (PropertyInfo propTo in to.GetType().GetProperties())
            {
                PropertyInfo propFrom = typeof(S).GetProperty(propTo.Name);
                if (propFrom == null)
                    continue;
                var value = propFrom.GetValue(from, null);
                if (value is ValueType || value is string)
                    propTo.SetValue(to, value);
            }
        }
        public static object CopyPropertiesToNew<S>(this S from, Type type)
        {
            object to = Activator.CreateInstance(type); // new object of Type
            from.CopyPropertiesTo(to);
            return to;
        }

        


        //public static BO.StudentCourse CopyToStudentCourse(this DO.Course course, DO.StudentInCourse sic)
        //{
        //    BO.StudentCourse result = (BO.StudentCourse)course.CopyPropertiesToNew(typeof(BO.StudentCourse));
        //    // propertys' names changed? copy them here...
        //    result.Grade = sic.Grade;
        //    return result;
        //}
    }
}
