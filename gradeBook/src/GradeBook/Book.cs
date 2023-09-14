
using GradeBoodk;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(Object snder, EventArgs args);

    public interface IBook
    {
        void AddGrades(double grade);
        public Statistics GetStatics();
        string Name { get; }
    }
    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public NamedObject(string name, DateTime addedDate)
        {
            Name = name;
            AddedDate = addedDate;
        }

        public string Name
        {
            get; set;
        }

        public DateTime AddedDate
        {
            get; set;
        }
    }

    public abstract class Book : NamedObject, IBook
    {
        protected Book(string name) : base(name)
        {
        }

        public abstract void AddGrades(double grade);

        public abstract Statistics GetStatics();
        public virtual void Run() {

        }


    }
    public class InMemmoryBook : Book
    {
        public List<double> grades;
        public string name;
        public static int x = 100;
        public double grade;
        public DateTime addedDate;
        //old way
        // public string Name {
        //     get {
        //         return name; 
        //     }
        //     set {
        //         if (!String.IsNullOrEmpty(value)) {
        //             Name = value;
        //         }
        //     }
        // }
        // public string Name{
        //     get;set; //atuto property
        // }
        public InMemmoryBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }

  
        public override void AddGrades(double grade)
        { //instance memenber of the Book Class
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }

        }

        public override void Run() {

        }

        public override Statistics GetStatics()
        {
            var result = new Statistics();

            foreach (double grade in grades)
            {
                result.Add(grade);
            }
            return result;

        }
        public event GradeAddedDelegate GradeAdded;
    }


    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override void AddGrades(double grade)
        {
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
            }
        }

        public override Statistics GetStatics()
        {
           var ressult = new Statistics();
           using (var reader = File.OpenText($"{Name}.txt")) {
            var line =  reader.ReadLine();
            while (line != null) {
                var number =  double.Parse(line);
                ressult.Add(number);
                line = reader.ReadLine();
            }
           }
           return ressult;
        }

    }

    //Inheritance


    // public class Book: NamedObject
    // {
    //     public List<double> grades;
    //     public string name;
    //     public static int x = 100;
    //     public double grade;
    //     public DateTime addedDate;
    //     //old way
    //     // public string Name {
    //     //     get {
    //     //         return name; 
    //     //     }
    //     //     set {
    //     //         if (!String.IsNullOrEmpty(value)) {
    //     //             Name = value;
    //     //         }
    //     //     }
    //     // }
    //     // public string Name{
    //     //     get;set; //atuto property
    //     // }
    //     public Book(string name): base(name){
    //         grades =  new List<double>();
    //         Name = name;
    //     }

    //     public Book(string name, DateTime addedDate): base(name, addedDate){
    //         grades =  new List<double>();
    //         Name = name;
    //         AddedDate = addedDate;
    //     }

    //     public void AddLetterGrade(char letter) {   
    //         switch(letter) {
    //             case 'A':
    //                 AddGrades(90);
    //                 break;
    //             case 'B':
    //                 AddGrades(80);
    //                 break;
    //             case 'C':
    //                 AddGrades(70);
    //                 break;   
    //             default:
    //                 AddGrades(0);      
    //                 break;   
    //         }
    //     }
    //     public void AddGrades(double grade) { //instance memenber of the Book Class
    //         if (grade <= 100 && grade >= 0) {
    //             grades.Add(grade);
    //             if (GradeAdded != null) {
    //                 GradeAdded(this, new EventArgs());
    //             }
    //         } else {
    //             throw new ArgumentException($"Invalid {nameof(grade)}");
    //         }

    //     }

    //     public Statistics GetStatics()
    //     {
    //         var result  = new Statistics();
    //         result.Average = 0.0;

    //         result.High = double.MinValue;
    //         result.Low  = double.MaxValue;
    //         foreach( double grade in grades) {
    //             result.Low = Math.Min(grade, result.Low);
    //             result.High =  Math.Max(grade, result.High);
    //             result.Average += grade;
    //         }
    //          result.Average /= grades.Count;

    //          switch(result.Average) {
    //             case var d when d > 90.0:
    //                 result.Letter = 'A';
    //                 break;
    //             case var d when d > 80.0:
    //                 result.Letter = 'B';
    //                 break;
    //             case var d when d > 70.0:
    //                 result.Letter = 'C';
    //                 break;       
    //             case var d when d > 60.0:
    //                 result.Letter = 'D';
    //                 break;     
    //             default:
    //                 result.Letter = 'F';
    //                 break; 
    //          }
    //          return result;


    //     }

    //     public event GradeAddedDelegate GradeAdded;


    // }

}