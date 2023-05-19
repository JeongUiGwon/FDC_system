using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SOM.Utils
{
    public class EmailValidator
    {
        public static bool IsValidEmail(string email)
        {
            // 이메일 형식을 검사하는 정규표현식입니다.
            string pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

            // 입력된 문자열이 정규표현식에 부합하는지 검사합니다.
            Match match = Regex.Match(email, pattern);

            // 검사 결과를 반환합니다.
            return match.Success;
        }
    }
}
