using _6SemCursach.BusinessLogic.Models;

namespace _6SemCursach.BusinessLogic.Services
{
    public class ServiceRegister: IRegister
    {
        private readonly ITeacher _teacher;
        private readonly IStudent _student;

        public ServiceRegister(ITeacher teacher, IStudent student)
        {
            _teacher = teacher;
            _student = student;
        }
        public void Registration(Register register)
        {
            if(register.Role == "Student")
            {
                _student.AddStudent(register);
            }

            if (register.Role == "Theacher")
            {
                _teacher.AddTeacher(register);
            }
        }
    }
}
