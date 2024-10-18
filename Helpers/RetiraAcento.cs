using System.Globalization;
using System.Text;


namespace SAP_MAGENTO.Helpers
{
    public static class RetiraAcento
    {
        public static string RetirarAcentuacao(string fullName)
        {
            StringBuilder sbReturn = new StringBuilder();   

            var arrayText = fullName.Normalize(NormalizationForm.FormD).ToCharArray();

           foreach (char letter in arrayText)
           {   
               if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
               sbReturn.Append(letter);   
           }   
            return sbReturn.ToString(); 
        }
    }
}