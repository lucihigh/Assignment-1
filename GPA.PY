def calculate_gpa(grades, credits):
    total_grade_points = 0
    total_credits = 0

    for grade, credit in zip(grades, credits):
        try:
            grade_point = float(grade)
            credit_value = int(credit)
            total_grade_points += grade_point * credit_value
            total_credits += credit_value
        except ValueError:
            print("Invalid input. Please enter numeric values for grades and credits.")
            return None

    if total_credits == 0:
        print("Total credits cannot be zero.")
        return None

    gpa = total_grade_points / total_credits
    return gpa

def main():
    student_name = input("Enter your name: ")
    grades = input("Enter your grades separated by spaces: ").split()
    credits = input("Enter the corresponding credits separated by spaces: ").split()

    gpa = calculate_gpa(grades, credits)
    if gpa is not None:
        print(f"Hello {student_name}, your GPA is: {gpa:.2f}")

        try:
            with open("gpa_results.txt", "w") as file:
                file.write(f"Student: {student_name}\n")
                file.write("Grades: " + ", ".join(grades) + "\n")
                file.write("Credits: " + ", ".join(credits) + "\n")
                file.write(f"GPA: {gpa:.2f}\n")
            print("GPA results saved to 'gpa_results.txt'")
        except IOError:
            print("Error: Unable to write to file.")

if __name__ == "__main__":
    main()

