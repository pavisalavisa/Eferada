namespace Business.Services
{
    public class GradeCalculator
    {
        //private const int MAX_ACADEMIC_YEAR=5;
        //private const int MAX_ECTS_PER_YEAR = 60;
        //private readonly IRepository<Student> _studentRepository;
        //private readonly IRepository<StudentCourse> _studentCourseRepository;
        //private readonly IRepository<Course> _courseRepository;

        //private readonly Dictionary<MedianGradeType, Func<StudentCourse, Course, decimal>> medianGradeTypeToCalculator =
        //    new Dictionary<MedianGradeType, Func<StudentCourse, Course, decimal>>
        //    {
        //        MedianGradeType.Median,
        //        (StudentCourse studentCourse, Course courses) => studentCourse.Sum(x => x.Grade) / studentCourse.Length,
        //        MedianGradeType.ECTSMedian,
        //        (StudentCourse studentCourse, Course courses) =>
        //            studentCourse.Sum(x => x.Grade * courses.First(y => y.Id == x.CourseId).ECTS) /
        //            courses.Where(x => x.Id == studentCourse.CourseId).Sum(x => x.ECTS)

        //    };
        //public GradeCalculator(IRepository<Student> studentRepository, IRepository<StudentCourse> studentCourseRepository, IRepository<Course> courseRepository)
        //{
        //    _studentRepository = studentRepository;
        //    _studentCourseRepository = studentCourseRepository;
        //    _courseRepository = courseRepository;
        //}

        //public decimal CalculateECTSMedianGrade(string username, int academicYear)
        //{
        //    return GenericCalculateMedianGrade(username, academicYear, MedianGradeType.ECTSMedian);
        //}

        //public decimal CalculateMedianGrade(string username, int academicYear)
        //{
        //    return GenericCalculateMedianGrade(username, academicYear, MedianGradeType.Median);
        //}

        //private decimal GenericCalculateMedianGrade(string username, int academicYear, MedianGradeType gradeType)
        //{
        //    if (!IsValidAcademicYear(academicYear))
        //    {
        //        throw new BusinessException("Incorrect academic year");
        //    }
        //    if (username == null)
        //    {
        //        throw new ArgumentNullException();
        //    }

        //    var student = await _studentRepository.GetFirstOrDefaultAsync(x => x.username == username).ConfigureAwait(false);
        //    if (student == null)
        //    {
        //        throw new BusinessException($"Cannot find student with username: {username}.");
        //    }

        //    var coursesAvailableOnAcademicYear = await _courseRepository.GetFirstOrDefaultAsync(x => x.academicYear == academicYear).ConfigureAwait(false);
        //    var studentCoursesTaken = await _studentCourseRepository.GetFirstOrDefaultAsync(x => x.studentId == student.Id).ConfigureAwait(false);

        //    var coursesTakenOnAcademicYear = studentCoursesTaken.Where(x => coursesAvailableOnAcademicYear.Contains(y => y.id == x.courseId));

        //    return medianGradeTypeToCalculator[gradeType](coursesTakenOnAcademicYear, coursesAvailableOnAcademicYear);
        //}
       
        //private bool IsValidAcademicYear(int academicYear)
        //{
        //    return academicYear > 0 && academicYear < MAX_ACADEMIC_YEAR;
        //}
    }
}