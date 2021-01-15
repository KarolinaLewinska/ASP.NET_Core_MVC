using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentsDataSystem.Models
{
    public class Student
    {
        public int id { get; set; }

        [DisplayName("Imiona")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        [StringLength(50, ErrorMessage = "Dozwolonych jest maksymalnie 50 znaków")]
        [RegularExpression(@"^[A-ZĘÓĄŚŁŻŹĆŃ]+[a-zęóąśłżźćńA-ZĘÓĄŚŁŻŹĆŃ ]*$",
        ErrorMessage = "Imię/Imiona muszą rozpoczynać się dużą literą i nie mogą zawierać znaków specjalnych")]
        public String names { get; set; }

        [DisplayName("Nazwisko")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        [StringLength(50, ErrorMessage = "Dozwolonych jest maksymalnie 50 znaków")]
        [RegularExpression(@"^[A-ZŻŹĆĄŚĘŁÓŃ]+[a-zżźćńółęąś]+[ \-]?[a-zęóąśłżźćńA-ZĘÓĄŚŁŻŹĆŃ ]*$",
        ErrorMessage = "Nazwisko musi rozpoczynać się dużą literą i nie może zawierać znaków specjalnych (oprócz myślnika)")]
        public String surname { get; set; }

        [DisplayName("Data urodzenia")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        [DateRange(ErrorMessage = "Nieprawidłowy zakres daty!")]
        [DisplayFormat(DataFormatString = "{0: dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime dateOfBirth { get; set; }

        [DisplayName("Miejsce urodzenia")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        [StringLength(50, ErrorMessage = "Dozwolonych jest maksymalnie 50 znaków")]
        [RegularExpression(@"^[A-ZŻŹĆĄŚĘŁÓŃ]+[a-zżźćńółęąś]+[ \-]?[a-zęóąśłżźćńA-ZĘÓĄŚŁŻŹĆŃ ]*$",
        ErrorMessage = "Miejsce urodzenia musi rozpoczynać się dużą literą i nie może zawierać znaków specjalnych")]
        public String placeOfBirth { get; set; }

        [DisplayName("Adres zamieszkania")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        [StringLength(100, ErrorMessage = "Dozwolonych jest maksymalnie 100 znaków")]
        [RegularExpression(@"^[A-ZĘÓĄŚŁŻŹĆŃ]+[a-zęóąśłżźćńA-ZĘÓĄŚŁŻŹĆŃ0-9-',''/' ]*$",
        ErrorMessage = "Adres zamieszkania musi rozpoczynać się dużą literą i nie może zawierać znaków specjalnych z wyjątkiem: , / -")]
        public String studentAddress { get; set; }

        [DisplayName("PESEL")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        [StringLength(11)]
        [RegularExpression(@"^[0-9]{11}$",
        ErrorMessage = "Numer PESEL musi się składać jedynie z 11 cyfr!")]
        public String pesel { get; set; }

        [DisplayName("Numer telefonu")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        [StringLength(9)]
        [RegularExpression(@"^[0-9]{9}$",
        ErrorMessage = "Numer telefonu musi się składać jedynie z 9 cyfr!")]
        public String phoneNumber { get; set; }
        
        [DisplayName("Adres e-mail")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        [StringLength(100, ErrorMessage = "Dozwolonych jest maksymalnie 100 znaków")]
        [RegularExpression(@"[a-z0-9!#$%&'\*\\\\+\\/=?^`{}|]{1}[a-z0-9!#$%&'\*\.\\\+\-\/=?^_`{}|]+@[a-z0-9.-]+\.[a-z]{2,4}$",
        ErrorMessage = "Adres e-mail musi składać się tylko z małych liter, musi zawierać znak @ oraz . i nie może rozpoczynać się . _ -")]
        public String email { get; set; }

        [DisplayName("Tryb studiów")]
        public String studiesType { get; set; }

        [DisplayName("Stopień studiów")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        public String degree { get; set; }

        [DisplayName("Kierunek")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        [StringLength(50, ErrorMessage = "Dozwolonych jest maksymalnie 50 znaków")]
        [RegularExpression(@"^[A-ZĘÓĄŚŁŻŹĆŃ]+[a-zęóąśłżźćńA-ZĘÓĄŚŁŻŹĆŃ'-' ]*$",
        ErrorMessage = "Kierunek musi rozpoczynać się dużą literą i nie może zawierać znaków specjalnych (oprócz myślnika)!")]
        public String fieldOfStudy { get; set; }

        [DisplayName("Specjalizacja")]
        [StringLength(50, ErrorMessage = "Dozwolonych jest maksymalnie 50 znaków")]
        [RegularExpression(@"^[A-ZĘÓĄŚŁŻŹĆŃ]+[a-zęóąśłżźćńA-ZĘÓĄŚŁŻŹĆŃ'-' ]*$",
        ErrorMessage = "Specjalizacja musi rozpoczynać się dużą literą i nie może zawierać znaków specjalnych (oprócz myślnika)!")]
        public String specialization { get; set; }

        [DisplayName("Semestr")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        public String semester { get; set; }

        [DisplayName("Grupa studencka")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        [StringLength(10, ErrorMessage = "Dozwolonych jest maksymalnie 10 znaków")]
        [RegularExpression(@"^[A-ZĘÓĄŚŁŻŹĆŃ]+[0-9- ]*$",
        ErrorMessage = "Grupa musi rozpoczynać się dużą literą, a potem zawierać jedynie cyfry i myślnik")]
        public String studentsGroup { get; set; }

        [DisplayName("Numer indeksu")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        [StringLength(6)]
        [RegularExpression(@"^[0-9]{6}$",
        ErrorMessage = "Numer indeksu musi się składać jedynie z 6 cyfr!")]
        public String studentIdNumber { get; set; }

        [DisplayName("Stypendium")]
        [StringLength(50, ErrorMessage = "Dozwolonych jest maksymalnie 50 znaków")]
        [RegularExpression(@"^[a-zęóąśłżźćńA-ZĘÓĄŚŁŻŹĆŃ0-9-',''/' ]*$",
        ErrorMessage = "Nazwa stypendium nie może zawierać znaków specjalnych z wyjątkiem: , / -")]
        public String scholarship { get; set; }

        public DateTime date = DateTime.Now;
        [DisplayName("Data modyfikacji")]
        public DateTime dateModified
        {
              get { return date; }
              set { date = value; }
        }
    }
}
