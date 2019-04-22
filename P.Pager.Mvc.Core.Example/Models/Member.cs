using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P.Pager.Mvc.Core.Example.Models
{
    public class Member
    {
        public int Id
        {
            set;
            get;
        }

        public string Name
        {
            set;
            get;
        }

        public string Company
        {
            set;
            get;
        }
    }

    public class DemoData
    {
        public List<Member> GetMembers()
        {
            var list = new List<Member> {
                new Member {
                    Id = 1,
                    Name = "Manson",
                    Company = "Manson"
                },
                new Member {
                    Id = 2,
                    Name = "RC",
                    Company = "RC"
                },
                new Member {
                    Id = 3,
                    Name = "Volvo",
                    Company = "Volvo"
                },
                new Member {
                    Id = 4,
                    Name = "Sam",
                    Company = "SamTec"
                },
                new Member {
                    Id = 5,
                    Name = "Manson",
                    Company = "Manson"
                },
                new Member {
                    Id = 6,
                    Name = "RC",
                    Company = "RC"
                },
                new Member {
                    Id = 7,
                    Name = "Volvo",
                    Company = "Volvo"
                },
                new Member {
                    Id = 8,
                    Name = "Sam",
                    Company = "SamTec"
                },
                new Member {
                    Id = 9,
                    Name = "Manson",
                    Company = "Manson"
                },
                new Member {
                    Id = 10,
                    Name = "RC",
                    Company = "RC"
                },
                new Member {
                    Id = 11,
                    Name = "Volvo",
                    Company = "Volvo"
                },
                new Member {
                    Id = 12,
                    Name = "Sam",
                    Company = "SamTec"
                },
                new Member {
                    Id = 13,
                    Name = "Manson",
                    Company = "Manson"
                },
                new Member {
                    Id = 14,
                    Name = "RC",
                    Company = "RC"
                },
                new Member {
                    Id = 15,
                    Name = "Volvo",
                    Company = "Volvo"
                },
                new Member {
                    Id = 16,
                    Name = "Sam",
                    Company = "SamTec"
                },
                new Member {
                    Id = 17,
                    Name = "Manson",
                    Company = "Manson"
                },
                new Member {
                    Id = 18,
                    Name = "RC",
                    Company = "RC"
                },
                new Member {
                    Id = 19,
                    Name = "Volvo",
                    Company = "Volvo"
                },
                new Member {
                    Id = 20,
                    Name = "Sam",
                    Company = "SamTec"
                },
                new Member {
                    Id = 21,
                    Name = "Manson",
                    Company = "Manson"
                },
                new Member {
                    Id = 22,
                    Name = "RC",
                    Company = "RC"
                },
                new Member {
                    Id = 23,
                    Name = "Volvo",
                    Company = "Volvo"
                },
                new Member {
                    Id = 24,
                    Name = "Sam",
                    Company = "SamTec"
                },
                new Member {
                    Id = 25,
                    Name = "Manson",
                    Company = "Manson"
                },
                new Member {
                    Id = 26,
                    Name = "RC",
                    Company = "RC"
                },
                new Member {
                    Id = 27,
                    Name = "Volvo",
                    Company = "Volvo"
                },
                new Member {
                    Id = 28,
                    Name = "Sam",
                    Company = "SamTec"
                },
                new Member {
                    Id = 29,
                    Name = "Sam",
                    Company = "SamTec"
                },
                new Member {
                    Id = 30,
                    Name = "Manson",
                    Company = "Manson"
                },
                new Member {
                    Id = 31,
                    Name = "RC",
                    Company = "RC"
                },
                new Member {
                    Id = 32,
                    Name = "Volvo",
                    Company = "Volvo"
                },
                new Member {
                    Id = 33,
                    Name = "Sam",
                    Company = "SamTec"
                },
                new Member {
                    Id = 34,
                    Name = "Manson",
                    Company = "Manson"
                },
                new Member {
                    Id = 35,
                    Name = "RC",
                    Company = "RC"
                },
                new Member {
                    Id = 36,
                    Name = "Volvo",
                    Company = "Volvo"
                },
                new Member {
                    Id = 37,
                    Name = "Sam",
                    Company = "SamTec"
                },
                new Member {
                    Id = 38,
                    Name = "Manson",
                    Company = "Manson"
                },
                new Member {
                    Id = 39,
                    Name = "RC",
                    Company = "RC"
                },
                new Member {
                    Id = 40,
                    Name = "Volvo",
                    Company = "Volvo"
                },
                new Member {
                    Id = 41,
                    Name = "Sam",
                    Company = "SamTec"
                },
                new Member {
                    Id = 42,
                    Name = "Manson",
                    Company = "Manson"
                },
                new Member {
                    Id = 43,
                    Name = "RC",
                    Company = "RC"
                },
                new Member {
                    Id = 44,
                    Name = "Volvo",
                    Company = "Volvo"
                },
                new Member {
                    Id = 45,
                    Name = "Sam",
                    Company = "SamTec"
                },
                new Member {
                    Id = 46,
                    Name = "Manson",
                    Company = "Manson"
                },
                new Member {
                    Id = 47,
                    Name = "RC",
                    Company = "RC"
                },
                new Member {
                    Id = 48,
                    Name = "Volvo",
                    Company = "Volvo"
                },
                new Member {
                    Id = 49,
                    Name = "Sam",
                    Company = "SamTec"
                },
                new Member {
                    Id = 50,
                    Name = "Manson",
                    Company = "Manson"
                },
                new Member {
                    Id = 51,
                    Name = "RC",
                    Company = "RC"
                },
                new Member {
                    Id = 52,
                    Name = "Volvo",
                    Company = "Volvo"
                },
                new Member {
                    Id = 53,
                    Name = "Sam",
                    Company = "SamTec"
                },
                new Member {
                    Id = 54,
                    Name = "Manson",
                    Company = "Manson"
                },
                new Member {
                    Id = 55,
                    Name = "RC",
                    Company = "RC"
                },
                new Member {
                    Id = 56,
                    Name = "Volvo",
                    Company = "Volvo"
                },
                new Member {
                    Id = 57,
                    Name = "Sam",
                    Company = "SamTec"
                },
                new Member {
                    Id = 58,
                    Name = "Manson",
                    Company = "Manson"
                },
                new Member {
                    Id = 59,
                    Name = "RC",
                    Company = "RC"
                },
                new Member {
                    Id = 60,
                    Name = "Volvo",
                    Company = "Volvo"
                },
                new Member {
                    Id = 61,
                    Name = "Sam",
                    Company = "SamTec"
                },
                new Member {
                    Id = 62,
                    Name = "Manson",
                    Company = "Manson"
                },
                new Member {
                    Id = 63,
                    Name = "RC",
                    Company = "RC"
                },
                new Member {
                    Id = 64,
                    Name = "Volvo",
                    Company = "Volvo"
                },
                new Member {
                    Id = 65,
                    Name = "Sam",
                    Company = "SamTec"
                },
                new Member {
                    Id = 66,
                    Name = "Manson",
                    Company = "Manson"
                },
                new Member {
                    Id = 67,
                    Name = "RC",
                    Company = "RC"
                },
                new Member {
                    Id = 68,
                    Name = "Volvo",
                    Company = "Volvo"
                },
                new Member {
                    Id = 69,
                    Name = "Sam",
                    Company = "SamTec"
                },
                new Member {
                    Id = 70,
                    Name = "Sam",
                    Company = "SamTec"
                }
            };
            return list;
        }
    }
}
