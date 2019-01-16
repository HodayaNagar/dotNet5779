using BE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    class Program
    {


        static void Main(string[] args)
        {

            try
            {


                // System.Console.WriteLine( DAL.Extensions.CalculateMD5Hash("12345674"));

                //Tester t = new Tester();
                //t.ID = "12345674";
                //t.FirstName = "mi";
                //t.LastName = "amor";
                //t.BirthDate = new DateTime(1979, 6, 3);
                //BL.FactorySingletonBL.Current.AddTester(t);
                //Test t = new Test();

                //BL.FactorySingletonBL.Current.AddTest(t, testerID, traineeID);


            }

            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            System.Console.ReadKey();
        }
    }
}
/*



    <?xml version="1.0" encoding="utf-8"?>
<Testers>
  <Tester>
    <ID>CF491AD9FF6D260618781D38B6DB65DC</ID>
    <FirstName>Tester0</FirstName>
    <LastName>Tester0</LastName>
    <BirthDate>1980-12-12T00:00:00</BirthDate>
    <Gender>Male</Gender>
    <Address>
      <City>Tel Aviv</City>
      <StreetName>Hagana</StreetName>
      <BuildingNumber>57</BuildingNumber>
    </Address>
    <Seniority>15</Seniority>
    <CarSpecializtion>Private</CarSpecializtion>
    <MaxWeeklyTests>2</MaxWeeklyTests>
    <WeeklyTests>0</WeeklyTests>
    <MaxDistanceInKilometers>20</MaxDistanceInKilometers>
  </Tester>
  <Tester>
    <ID>0B3A0C079C243E042FB5DC47AEC2B771</ID>
    <FirstName>Tester1</FirstName>
    <LastName>Tester1</LastName>
    <BirthDate>1970-12-12T00:00:00</BirthDate>
    <Gender>Female</Gender>
    <Address>
      <City>Tel Aviv</City>
      <StreetName>Hagana</StreetName>
      <BuildingNumber>56</BuildingNumber>
    </Address>
    <Seniority>14</Seniority>
    <CarSpecializtion>Private</CarSpecializtion>
    <MaxWeeklyTests>5</MaxWeeklyTests>
    <WeeklyTests>0</WeeklyTests>
    <MaxDistanceInKilometers>20</MaxDistanceInKilometers>
  </Tester>
  <Tester>
    <ID>3567D9902D8C4E24DEB207D5134819FD</ID>
    <FirstName>Tester2</FirstName>
    <LastName>Tester2</LastName>
    <BirthDate>1975-12-12T00:00:00</BirthDate>
    <Gender>Female</Gender>
    <Address>
      <City>Tel Aviv</City>
      <StreetName>Hagana</StreetName>
      <BuildingNumber>50</BuildingNumber>
    </Address>
    <Seniority>14</Seniority>
    <CarSpecializtion>Private</CarSpecializtion>
    <MaxWeeklyTests>5</MaxWeeklyTests>
    <WeeklyTests>1</WeeklyTests>
    <MaxDistanceInKilometers>50</MaxDistanceInKilometers>
  </Tester>
</Testers>






    <?xml version="1.0" encoding="utf-8"?>
<Tests>
  <Test>
    <TestID>10000000</TestID>
    <TraineeID>E446992C40B9733E3A08057CD32483D3</TraineeID>
    <TesterID>3567D9902D8C4E24DEB207D5134819FD</TesterID>
    <TestTime>0001-01-01T00:00:00</TestTime>
    <Result>Passed</Result>
    <CarType>Private</CarType>
  </Test>
</Tests>





    <?xml version="1.0" encoding="utf-8"?>
<Trainees>
  <Trainee>
    <ID>E446992C40B9733E3A08057CD32483D3</ID>
    <FirstName>Trainee0</FirstName>
    <LastName>Trainee0</LastName>
    <BirthDate>1999-12-12T00:00:00</BirthDate>
    <Gender>Male</Gender>
    <Address>
      <City>Tel Aviv</City>
      <StreetName>Hagana</StreetName>
      <BuildingNumber>57</BuildingNumber>
    </Address>
    <CarTrained>Private</CarTrained>
    <GearType>Automatic</GearType>
    <DrivingSchool>smartdrive</DrivingSchool>
    <TotalLessonsNumber>28</TotalLessonsNumber>
    <DrivingInstructorFirstName>Tester2</DrivingInstructorFirstName>
    <DrivingInstructorLastName>Tester2</DrivingInstructorLastName>
  </Trainee>
  <Trainee>
    <ID>314953776F0C08AAD429A1D1B7C39F63</ID>
    <FirstName>Trainee1</FirstName>
    <LastName>Trainee1</LastName>
    <BirthDate>2000-12-12T00:00:00</BirthDate>
    <Gender>Male</Gender>
    <Address>
      <City>Tel Aviv</City>
      <StreetName>Hagana</StreetName>
      <BuildingNumber>56</BuildingNumber>
    </Address>
    <CarTrained>Private</CarTrained>
    <GearType>Automatic</GearType>
    <DrivingSchool>smartdrive</DrivingSchool>
    <TotalLessonsNumber>30</TotalLessonsNumber>
    <DrivingInstructorFirstName>Instructor1</DrivingInstructorFirstName>
    <DrivingInstructorLastName>of trainee ID:1</DrivingInstructorLastName>
  </Trainee>
  <Trainee>
    <ID>755F801D34CB6E95E618C6AA80E04B04</ID>
    <FirstName>Trainee2</FirstName>
    <LastName>Trainee2</LastName>
    <BirthDate>2000-12-12T00:00:00</BirthDate>
    <Gender>Male</Gender>
    <Address>
      <City>Tel Aviv</City>
      <StreetName>Hagana</StreetName>
      <BuildingNumber>52</BuildingNumber>
    </Address>
    <CarTrained>Private</CarTrained>
    <GearType>Automatic</GearType>
    <DrivingSchool>smartdrive</DrivingSchool>
    <TotalLessonsNumber>30</TotalLessonsNumber>
    <DrivingInstructorFirstName>Instructor2</DrivingInstructorFirstName>
    <DrivingInstructorLastName>of trainee ID:2</DrivingInstructorLastName>
  </Trainee>
</Trainees>

 */
