def calculate_gpa(grades, credits):
    total_grade_points = 0
    total_credits = 0
# Dòng này xác định hàm tính toán_gpa với hai tham số: điểm (danh sách điểm) và tín chỉ (danh sách tín chỉ tương ứng)
    for grade, credit in zip(grades, credits):
        try:
            grade_point = float(grade) #chuyển đổi điểm thành số dấu phẩy động
            credit_value = int(credit) #chuyển đổi tín dụng thành số nguyên
            total_grade_points += grade_point * credit_value
            total_credits += credit_value
        except ValueError:
            print("Invalid input. Please enter numeric values for grades and credits.")
            return None

    if total_credits == 0:#kiểm tra tín chỉ có bằng 0 hay không r trả lại ban đầu
        print("Total credits cannot be zero.")
        return None

    gpa = total_grade_points / total_credits
    return gpa

def main():
    student_name = input("Enter your name: ")#Dòng này dùng nhập tên và lưu dữ liệu đầu vào vào student_name
    grades = input("Enter your grades separated by spaces: ").split()#Dòng này dùng nhập điểm, phân tách bằng dấu cách, chia đầu vào danh sách qua spilit
    credits = input("Enter the corresponding credits separated by spaces: ").split()# Tương tự điểm 

    gpa = calculate_gpa(grades, credits)# hàm tính 
    if gpa is not None:# kiểm tra gpa có bằng null hay không
        print(f"Hello {student_name}, your GPA is: {gpa:.2f}")#in ra thông báo tên, điểm gpa(được định dạng thành hai chữ số thập phân)

        try:# bắt đầu để sử lý lỗi trước khi in vào tệp
            with open("gpa_results.txt", "w") as file:# mở một tệp ở chế độ ghi và gán biến vào tệp
                file.write(f"Student: {student_name}\n")#Ghi tên học sinh vào hồ sơ
                file.write("Grades: " + ", ".join(grades) + "\n")#Ghi danh sách điểm vào tập tin, nối bằng dấu phẩy
                file.write("Credits: " + ", ".join(credits) + "\n")#Viết danh sách các khoản tín dụng vào tập tin, nối bằng dấu phẩy
                file.write(f"GPA: {gpa:.2f}\n")#Ghi điểm trung bình được tính vào tệp, được định dạng thành hai chữ số thập phân
            print("GPA results saved to 'gpa_results.txt'")#in đã được in thành công vào tệp
        except IOError:
            print("Error: Unable to write to file.")#in lỗi khi không thể ghi vào tệp

if __name__ == "__main__":
    main()
