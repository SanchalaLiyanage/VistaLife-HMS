Create Database VistaLife

drop database VistaLife


Create Table Ward
(
	W_ID varchar(10) not null Primary key check(W_ID like 'W%'),
	W_Name varchar(50) not null,
	NoOf_Bed int not null,
);



Create Table nurse
(
    N_ID varchar(10)not null primary key check(N_ID like 'N%'),
	N_Name varchar(50)not null,
	N_Experience varchar(20),
	N_Age int not null,
	N_Address varchar(20) not null,
	W_ID varchar(10) foreign key references Ward(W_ID)
);

Create Table Doctor --15 data 
(
    D_ID varchar(10)not null primary key check(D_ID like 'D%'),
	D_Name varchar(50)not null,
	D_Expirenace varchar(20)not null,
	D_Speciality varchar(100)not null,
	D_Age int not null,
	D_Address varchar(20) not null,
	D_type varchar(20)not null
);


Create Table patient  --15 data
(
    P_ID varchar(10) not null primary key check(P_ID like 'P%'),
	P_Name varchar(50)not null,
	P_Age int not null,
	P_Address varchar(50) not null,
);

Create Table IN_Patient
(
    IP_ID varchar(10)not null primary key,

	IP_Blood_Type varchar(20)not null,
	IP_Guardian_Name varchar(50)not null,
	W_ID varchar(10) not null foreign key references Ward(W_ID),
	IP_Admitted_Date varchar(15) Not null,
	IP_Discharge_Date varchar(15),
	P_ID varchar(10) foreign key references patient(P_ID)
);
CREATE TABLE OutPatient
(
OP_ID VARCHAR(10)not null primary key check(OP_ID Like 'OP%'),
Dates varchar(15) Not null,
P_ID varchar(10) foreign key references patient(P_ID)
);


Create Table Ward_InPatient_Doctor
(
	AD_ID Varchar(10) Primary key Not null check(AD_ID Like 'AD%'),
	IP_ID Varchar(10) Foreign Key references IN_Patient(IP_ID),
	D_ID Varchar(10) Foreign Key references Doctor(D_ID),
	W_ID Varchar(10) Foreign Key references Ward(W_ID),
	
);

(
	AP_ID Varchar(10) Primary Key Not null Check(AP_ID Like 'AP%'),
	OP_ID Varchar(10) Foreign Key references OutPatient(OP_ID),
	D_ID Varchar(10) Foreign Key references Doctor(D_ID),
	Payment_type varchar(20)  ,
	Bill float 
);



Create Table Extra_Services
(
	S_ID Varchar(10) Primary Key Not Null Check(S_ID Like 'S%'),
	S_Name Varchar(50) ,
	S_Cost float 
);


Create Table Bill
(
	P_ID Varchar(10) Foreign Key References patient(P_ID),
	IP_ID Varchar(10) Foreign Key References IN_Patient(IP_ID),
	OP_ID Varchar(10) Foreign Key references OutPatient(OP_ID),
	B_ID varchar (10) Primary Key,

	cost varchar(15) ,
	Payment_type Varchar(25) 
	
);

create table Users
(
	U_Name varchar(10) Primary key,
	PW Varchar(10),
);
INSERT INTO Users(U_Name,PW)
VALUES
('Admin123','123'),
('User123','123')


INSERT INTO Ward (W_ID, W_Name, NoOf_Bed) 
VALUES 
('W001', 'General Ward', 20),
('W002', 'Pediatric Ward', 15),
('W003', 'Surgical Ward', 25),
('W004', 'Maternity Ward', 10),
('W005', 'Emergency Ward', 30),
('W006', 'Intensive Care Unit', 10),
('W007', 'Oncology Ward', 12),
('W008', 'Psychiatric Ward', 15),
('W009', 'Orthopedic Ward', 18),
('W010', 'Neurology Ward', 20);

INSERT INTO nurse (N_ID, N_Name, N_Experience, N_Age, N_Address, W_ID) VALUES
('N001', 'Ms. Priyanthi Silva', '10 years', 32, 'Colombo', 'W001'),
('N002', 'Ms. Kumari Rajapaksa', '8 years', 30, 'Kandy', 'W002'),
('N003', 'Ms. Dilrukshi Fernando', '12 years', 35, 'Galle', 'W003'),
('N004', 'Ms. Anusha Perera', '7 years', 28, 'Matara', 'W004'),
('N005', 'Ms. Sujatha de Silva', '9 years', 31, 'Colombo', 'W005'),
('N006', 'Ms. Chathurika Bandara', '11 years', 34, 'Kandy', 'W006'),
('N007', 'Ms. Samanthi Gunaratne', '6 years', 27, 'Galle', 'W007'),
('N008', 'Ms. Chamari Jayawardena', '13 years', 36, 'Matara', 'W008'),
('N009', 'Ms. Indika Ranasinghe', '10 years', 33, 'Colombo', 'W009'),
('N010', 'Ms. Nirosha de Silva', '8 years', 29, 'Kandy', 'W010');




INSERT INTO Doctor (D_ID, D_Name, D_Expirenace, D_Speciality, D_Age, D_Address, D_type) VALUES
('D001', 'Dr. Chaminda Perera', '15 years', 'Cardiology', 45, 'Colombo', 'Senior'),
('D002', 'Dr. Malini Rajapaksa', '12 years', 'Pediatrics', 40, 'Kandy', 'Senior'),
('D003', 'Dr. Nimal Fernando', '20 years', 'Orthopedics', 50, 'Galle', 'Senior'),
('D004', 'Dr. Priyantha Silva', '10 years', 'Obstetrics and Gynecology', 38, 'Matara', 'Junior'),
('D005', 'Dr. Shanthi de Silva', '8 years', 'Dermatology', 35, 'Colombo', 'Junior'),
('D006', 'Dr. Ravi Bandara', '18 years', 'Oncology', 55, 'Kandy', 'Senior'),
('D007', 'Dr. Anusha Gunaratne', '13 years', 'Neurology', 42, 'Galle', 'Senior'),
('D008', 'Dr. Sunil Jayawardena', '9 years', 'ENT (Otolaryngology)', 37, 'Matara', 'Junior'),
('D009', 'Dr. Kanchana Ranasinghe', '14 years', 'Urology', 48, 'Colombo', 'Senior'),
('D010', 'Dr. Chamari de Silva', '11 years', 'Endocrinology', 39, 'Kandy', 'Junior'),
('D011', 'Dr. Nirosha Perera', '16 years', 'Ophthalmology', 47, 'Galle', 'Senior'),
('D012', 'Dr. Tharanga Bandara', '7 years', 'Psychiatry', 33, 'Matara', 'Junior'),
('D013', 'Dr. Sanjeewa Jayasuriya', '19 years', 'Pulmonology', 57, 'Colombo', 'Senior'),
('D014', 'Dr. Dilshan Gunawardena', '10 years', 'Gastroenterology', 36, 'Kandy', 'Junior'),
('D015', 'Dr. Chaminda Rajapaksa', '21 years', 'Hematology', 60, 'Galle', 'Senior');



-- Insert data into Patient table
INSERT INTO patient (P_ID, P_Name, P_Age, P_Address) VALUES
('P001', 'Mr. Sunil Perera', 45, 'Colombo'),
('P002', 'Ms. Anula Silva', 30, 'Kandy'),
('P003', 'Mr. Chandana Fernando', 55, 'Galle'),
('P004', 'Ms. Priya Rajapaksa', 22, 'Matara'),
('P005', 'Mr. Kamal Jayawardena', 38, 'Colombo'),
('P006', 'Ms. Sandya de Silva', 27, 'Kandy'),
('P007', 'Mr. Asanka Bandara', 50, 'Galle'),
('P008', 'Ms. Samanthi Gunaratne', 33, 'Matara'),
('P009', 'Mr. Sanjeewa Ranasinghe', 48, 'Colombo'),
('P010', 'Ms. Malini de Mel', 40, 'Kandy');

-- Insert data into IN_Patient table
INSERT INTO IN_Patient (IP_ID, IP_Blood_Type, IP_Guardian_Name, W_ID, IP_Admitted_Date, IP_Discharge_Date, P_ID) VALUES
('IP001', 'A+', 'Mrs. Kamala Perera', 'W001', '2023-01-01', '2023-01-10', 'P001'),
('IP002', 'O-', 'Mr. Ranjith Silva', 'W002', '2023-02-15', '2023-03-05', 'P002'),
('IP003', 'B+', 'Mr. Nimal Fernando', 'W003', '2023-03-20', '2023-04-10', 'P003'),
('IP004', 'AB-', 'Mrs. Sandya Rajapaksa', 'W004', '2023-04-05', '2023-04-20', 'P004'),
('IP005', 'A-', 'Mr. Sunil Jayawardena', 'W005', '2023-05-10', '2023-05-25', 'P005'),
('IP006', 'O+', 'Mrs. Malini de Silva', 'W006', '2023-06-15', '2023-06-30', 'P006'),
('IP007', 'B-', 'Mr. Sanath Bandara', 'W007', '2023-07-20', '2023-08-05', 'P007'),
('IP008', 'AB+', 'Mrs. Tharanga Gunaratne', 'W008', '2023-08-25', '2023-09-10', 'P008'),
('IP009', 'A+', 'Mr. Chaminda Perera', 'W009', '2023-09-10', '2023-09-25', 'P009'),
('IP010', 'O-', 'Ms. Priyanthi Fernando', 'W010', '2023-10-15', '2023-11-05', 'P010');

-- Insert data into OutPatient table
INSERT INTO OutPatient (OP_ID, Dates, P_ID) VALUES
('OP001', '2023-01-05', 'P001'),
('OP002', '2023-02-20', 'P001'),
('OP003', '2023-03-25', 'P002'),
('OP004', '2023-04-10', 'P003'),
('OP005', '2023-05-15', 'P004'),
('OP006', '2023-06-30', 'P005'),
('OP007', '2023-07-05', 'P006'),
('OP008', '2023-08-10', 'P007'),
('OP009', '2023-09-25', 'P008'),
('OP010', '2023-10-30', 'P009');


-- Additional data for IN_Patient table
INSERT INTO IN_Patient (IP_ID, IP_Blood_Type, IP_Guardian_Name, W_ID, IP_Admitted_Date, IP_Discharge_Date, P_ID) VALUES
('IP011', 'B+', 'Mr. Ajith Ranasinghe', 'W001', '2023-11-10', '2023-12-05', 'P001'),
('IP012', 'AB-', 'Mrs. Sujatha Jayawardena', 'W002', '2023-12-20', '2024-01-10', 'P002'),
('IP013', 'O+', 'Mr. Saman Perera', 'W003', '2024-01-15', '2024-02-05', 'P003'),
('IP014', 'A-', 'Mrs. Anoma Gunaratne', 'W004', '2024-02-20', '2024-03-05', 'P004'),
('IP015', 'B-', 'Mr. Chamara Silva', 'W005', '2024-03-10', '2024-04-05', 'P005'),
('IP016', 'A+', 'Mrs. Thilini Rajapaksa', 'W006', '2024-04-20', '2024-05-10', 'P006'),
('IP017', 'O-', 'Mr. Dinesh Bandara', 'W007', '2024-05-15', '2024-06-05', 'P007'),
('IP018', 'AB+', 'Mrs. Chathurika Fernando', 'W008', '2024-06-10', '2024-07-05', 'P008'),
('IP019', 'B+', 'Mr. Ruwan Perera', 'W009', '2024-07-20', '2024-08-05', 'P009'),
('IP020', 'A-', 'Mrs. Deepthi de Silva', 'W010', '2024-08-10', '2024-09-05', 'P010');

-- Additional data for OutPatient table
INSERT INTO OutPatient (OP_ID, Dates, P_ID) VALUES
('OP011', '2023-11-15', 'P001'),
('OP012', '2023-12-30', 'P001'),
('OP013', '2024-01-25', 'P002'),
('OP014', '2024-02-10', 'P003'),
('OP015', '2024-03-15', 'P004'),
('OP016', '2024-04-30', 'P005'),
('OP017', '2024-05-05', 'P006'),
('OP018', '2024-06-10', 'P007'),
('OP019', '2024-07-25', 'P008'),
('OP020', '2024-08-30', 'P009');

-- Insert 10 more rows into IN_Patient table
INSERT INTO IN_Patient (IP_ID, IP_Blood_Type, IP_Guardian_Name, W_ID, IP_Admitted_Date, IP_Discharge_Date, P_ID) VALUES
('IP021', 'A+', 'Mr. Chaminda Perera', 'W001', '2023-11-01', '2023-11-10', 'P002'),
('IP022', 'O-', 'Mrs. Sandya Rajapaksa', 'W002', '2023-11-15', '2023-12-05', 'P002'),
('IP023', 'B+', 'Mr. Nimal Fernando', 'W003', '2023-12-20', '2024-01-10', 'P002'),
('IP024', 'AB-', 'Mrs. Kamala Perera', 'W004', '2024-01-05', '2024-01-20', 'P002'),
('IP025', 'A-', 'Mr. Sunil Jayawardena', 'W005', '2024-02-10', '2024-02-25', 'P002'),
('IP026', 'O+', 'Mrs. Malini de Silva', 'W006', '2024-03-15', '2024-03-30', 'P002'),
('IP027', 'B-', 'Mr. Sanath Bandara', 'W007', '2024-04-20', '2024-05-05', 'P002'),
('IP028', 'AB+', 'Mrs. Tharanga Gunaratne', 'W008', '2024-05-25', '2024-06-10', 'P002'),
('IP029', 'A+', 'Mr. Ranjith Silva', 'W009', '2024-06-10', '2024-06-25', 'P002'),
('IP030', 'O-', 'Ms. Priyanthi Fernando', 'W010', '2024-07-15', '2024-08-05', 'P002');

-- Insert 10 more rows into OutPatient table
INSERT INTO OutPatient (OP_ID, Dates, P_ID) VALUES
('OP021', '2023-11-10', 'P002'),
('OP022', '2023-12-15', 'P002'),
('OP023', '2024-01-20', 'P002'),
('OP024', '2024-02-05', 'P002'),
('OP025', '2024-03-10', 'P002'),
('OP026', '2024-04-25', 'P002'),
('OP027', '2024-05-10', 'P002'),
('OP028', '2024-06-15', 'P002'),
('OP029', '2024-07-20', 'P002'),
('OP030', '2024-08-25', 'P002');

-- Additional 10 rows for IN_Patient table
INSERT INTO IN_Patient (IP_ID, IP_Blood_Type, IP_Guardian_Name, W_ID, IP_Admitted_Date, IP_Discharge_Date, P_ID) VALUES
('IP031', 'A+', 'Mr. Dilshan Perera', 'W001', '2023-09-15', '2023-09-30', 'P003'),
('IP032', 'O-', 'Mrs. Sanduni Rajapaksa', 'W002', '2023-10-10', '2023-10-25', 'P003'),
('IP033', 'B+', 'Mr. Nishantha Fernando', 'W003', '2023-11-05', '2023-11-20', 'P003'),
('IP034', 'AB-', 'Mrs. Kamani Perera', 'W004', '2023-12-01', '2023-12-15', 'P003'),
('IP035', 'A-', 'Mr. Sunil Jayaweera', 'W005', '2024-01-10', '2024-01-25', 'P003'),
('IP036', 'O+', 'Mrs. Malini de Alwis', 'W006', '2024-02-05', '2024-02-20', 'P003'),
('IP037', 'B-', 'Mr. Sampath Bandara', 'W007', '2024-03-01', '2024-03-15', 'P003'),
('IP038', 'AB+', 'Mrs. Tharika Gunaratne', 'W008', '2024-04-10', '2024-04-25', 'P003'),
('IP039', 'A+', 'Mr. Ranjith Senaratne', 'W009', '2024-05-05', '2024-05-20', 'P003'),
('IP040', 'O-', 'Ms. Priyanthi de Silva', 'W010', '2024-06-01', '2024-06-15', 'P003');



INSERT INTO Doctor_OutPatient (AP_ID, OP_ID, D_ID)
VALUES 
    ('AP001', 'OP001', 'D001'),
    ('AP002', 'OP002', 'D002'),
    ('AP003', 'OP003', 'D003'),
    ('AP004', 'OP004', 'D004'),
    ('AP005', 'OP005', 'D005'),
    ('AP006', 'OP006', 'D006'),
    ('AP007', 'OP007', 'D007'),
    ('AP008', 'OP008', 'D008'),
    ('AP009', 'OP009', 'D009'),
    ('AP010', 'OP010', 'D010');

	INSERT INTO Doctor_OutPatient (AP_ID, OP_ID, D_ID, Payment_type, Bill)
VALUES 
    ('AP011', 'OP011', 'D001', 'Cash', 2100.00),
    ('AP012', 'OP012', 'D002', 'Card', 2200.00),
    ('AP013', 'OP013', 'D003', 'Insurance', 2300.00),
    ('AP014', 'OP014', 'D004', 'Cash', 2400.00),
    ('AP015', 'OP015', 'D005', 'Card', 2500.00),
    ('AP016', 'OP016', 'D006', 'Insurance', 2600.00),
    ('AP017', 'OP017', 'D007', 'Cash', 2700.00),
    ('AP018', 'OP018', 'D008', 'Card', 2800.00),
    ('AP019', 'OP019', 'D009', 'Insurance', 2900.00),
    ('AP020', 'OP020', 'D010', 'Cash', 3000.00),
    ('AP021', 'OP021', 'D001', 'Cash', 3100.00),
    ('AP022', 'OP022', 'D002', 'Card', 3200.00),
    ('AP023', 'OP023', 'D003', 'Insurance', 3300.00),
    ('AP024', 'OP024', 'D004', 'Cash', 3400.00),
    ('AP025', 'OP025', 'D005', 'Card', 3500.00),
    ('AP026', 'OP026', 'D006', 'Insurance', 3600.00),
    ('AP027', 'OP027', 'D007', 'Cash', 3700.00),
    ('AP028', 'OP028', 'D008', 'Card', 3800.00),
    ('AP029', 'OP029', 'D009', 'Insurance', 3900.00),
    ('AP030', 'OP030', 'D010', 'Cash', 4000.00)
   


	INSERT INTO Ward_InPatient_Doctor (AD_ID, IP_ID, D_ID, W_ID)
VALUES 
    ('AD001', 'IP001', 'D001', 'W001'),
    ('AD002', 'IP002', 'D002', 'W002'),
    ('AD003', 'IP003', 'D003', 'W003'),
    ('AD004', 'IP004', 'D004', 'W004'),
    ('AD005', 'IP005', 'D005', 'W005'),
    ('AD006', 'IP006', 'D006', 'W006'),
    ('AD007', 'IP007', 'D007', 'W007'),
    ('AD008', 'IP008', 'D008', 'W008'),
    ('AD009', 'IP009', 'D009', 'W009'),
    ('AD010', 'IP010', 'D010', 'W010');

	INSERT INTO Ward_InPatient_Doctor (AD_ID, IP_ID, D_ID, W_ID, Payment_type, Bill)
VALUES 
    ('AD011', 'IP011', 'D001', 'W001', 'Cash', 52000.00),
    ('AD012', 'IP012', 'D002', 'W002', 'Insurance', 53000.00),
    ('AD013', 'IP013', 'D003', 'W003', 'Credit Card', 54000.00),
    ('AD014', 'IP014', 'D004', 'W004', 'Cash', 55000.00),
    ('AD015', 'IP015', 'D005', 'W005', 'Cash', 56000.00),
    ('AD016', 'IP016', 'D006', 'W006', 'Insurance', 57000.00),
    ('AD017', 'IP017', 'D007', 'W007', 'Credit Card', 58000.00),
    ('AD018', 'IP018', 'D008', 'W008', 'Cash', 59000.00),
    ('AD019', 'IP019', 'D009', 'W009', 'Cash', 60000.00),
    ('AD020', 'IP020', 'D010', 'W010', 'Insurance', 61000.00),
    ('AD021', 'IP021', 'D001', 'W001', 'Cash', 62000.00),
    ('AD022', 'IP022', 'D002', 'W002', 'Insurance', 63000.00),
    ('AD023', 'IP023', 'D003', 'W003', 'Credit Card', 64000.00),
    ('AD024', 'IP024', 'D004', 'W004', 'Cash', 65000.00),
    ('AD025', 'IP025', 'D005', 'W005', 'Cash', 66000.00),
    ('AD026', 'IP026', 'D006', 'W006', 'Insurance', 67000.00),
    ('AD027', 'IP027', 'D007', 'W007', 'Credit Card', 68000.00),
    ('AD028', 'IP028', 'D008', 'W008', 'Cash', 69000.00),
    ('AD029', 'IP029', 'D009', 'W009', 'Cash', 70000.00),
    ('AD030', 'IP030', 'D010', 'W010', 'Insurance', 71000.00),
    ('AD031', 'IP031', 'D001', 'W001', 'Cash', 72000.00),
    ('AD032', 'IP032', 'D002', 'W002', 'Insurance', 73000.00),
    ('AD033', 'IP033', 'D003', 'W003', 'Credit Card', 74000.00),
    ('AD034', 'IP034', 'D004', 'W004', 'Cash', 75000.00),
    ('AD035', 'IP035', 'D005', 'W005', 'Cash', 76000.00),
    ('AD036', 'IP036', 'D006', 'W006', 'Insurance', 77000.00),
    ('AD037', 'IP037', 'D007', 'W007', 'Credit Card', 78000.00),
    ('AD038', 'IP038', 'D008', 'W008', 'Cash', 79000.00),
    ('AD039', 'IP039', 'D009', 'W009', 'Cash', 80000.00),
    ('AD040', 'IP040', 'D010', 'W010', 'Insurance', 81000.00);

	INSERT INTO Bill (P_ID, IP_ID, OP_ID, B_ID, cost, Payment_type)
VALUES 
    ('P001', 'IP011', NULL, 'B001', '2000', 'Cash'),
    ('P002', 'IP012', NULL, 'B002', '3000', 'Credit Card'),
    ('P003', 'IP013', NULL, 'B003', '4000', 'Insurance'),
    ('P004', 'IP014', NULL, 'B004', '5000', 'Cash'),
    ('P005', 'IP015', NULL, 'B005', '6000', 'Cash'),
    ('P006', 'IP016', NULL, 'B006', '7000', 'Cash'),
    ('P007', 'IP017', NULL, 'B007', '8000', 'Credit Card'),
    ('P008', 'IP018', NULL, 'B008', '9000', 'Cash'),
    ('P009', 'IP019', NULL, 'B009', '10000', 'Cash'),
    ('P010', 'IP020', NULL, 'B010', '11000', 'Cash'),
    ('P001', NULL, 'OP021', 'B011', '12000', 'Cash'),
    ('P002', NULL, 'OP022', 'B012', '13000', 'Credit Card'),
    ('P003', NULL, 'OP023', 'B013', '14000', 'Insurance'),
    ('P004', NULL, 'OP024', 'B014', '15000', 'Cash'),
    ('P005', NULL, 'OP025', 'B015', '16000', 'Cash'),
    ('P006', 'IP026', NULL, 'B016', '17000', 'Cash'),
    ('P007', 'IP027', NULL, 'B017', '18000', 'Credit Card'),
    ('P008', 'IP028', NULL, 'B018', '19000', 'Cash'),
    ('P009', 'IP029', NULL, 'B019', '20000', 'Cash'),
    ('P010', 'IP030', NULL, 'B020', '21000', 'Cash'),
    ('P001', NULL, 'OP011', 'B021', '22000', 'Cash'),
    ('P002', NULL, 'OP022', 'B022', '23000', 'Credit Card'),
    ('P003', NULL, 'OP023', 'B023', '24000', 'Insurance'),
    ('P004', NULL, 'OP024', 'B024', '25000', 'Cash'),
    ('P005', NULL, 'OP025', 'B025', '26000', 'Cash'),
    ('P006', 'IP036', NULL, 'B026', '27000', 'Cash'),
    ('P007', 'IP037', NULL, 'B027', '28000', 'Credit Card'),
    ('P008', 'IP038', NULL, 'B028', '29000', 'Cash'),
    ('P009', 'IP039', NULL, 'B029', '30000', 'Cash'),
    ('P010', 'IP040', NULL, 'B030', '31000', 'Cash');



INSERT INTO  Extra_Services (S_ID, S_Name, S_Cost) VALUES
('S001', 'Blood Report', 1500),
('S002', 'x-ray', 1500),
('S003', 'MRI-Scan', 25000),
('S004', 'Eco Test', 8000),
('S005', 'CT-Scan', 50000),
('S006', 'ECG Test', 5000),
('S007', 'EndoscopyTest', 3000),
('S008', 'EEG', 2000)


