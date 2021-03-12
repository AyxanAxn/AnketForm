using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnketForm
{
    class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNum { get; set; }
        public string Gender { get; set; }
        public List<string> Language { get; set; }
        public string Skills { get; set; }
        public string Education { get; set; }
        public DateTime Brith { get; set; }


        public override string ToString()
        {
            return $"\nName - {Name}\nSurname - {Surname}\nPhone - {PhoneNum}\nGender - {Gender}\nLanguage - {Language}\nSkills - {Skills}\nEducation - {Education}\nBrithday - {Brith}";
        }

    }
}
