using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class StandardGradeBook : BaseGradeBook
    {
        public StandardGradeBook(string name, GradeBookType type) : base(name)
        {
            base.Type = type;
        }
    }
}
