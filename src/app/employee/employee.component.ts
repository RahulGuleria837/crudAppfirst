import { Component,OnInit } from '@angular/core';
import { Employee } from '../employee';
import { EmployeeService } from '../employee.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss']
})
export class EmployeeComponent {

employeeList:Employee[]=[];
newEmployee:Employee= new Employee();
editEmployee:Employee= new Employee();

constructor(private employeeService:EmployeeService){}

ngOnInit(): void{
  this.getAll();
}

getAll()
{
  this.employeeService.getAllEmployee().subscribe(
    (response)=>{
      this.employeeList=response;
      console.log(response);
    },
    (error)=>{
      console.log(error);
    }
    )

}
saveClick()
{
  this.newEmployee.id=0;
  this.employeeService.saveEmployee(this.newEmployee).subscribe(

  (response)=>{
    alert('data saved')
    this.getAll();
    this.newEmployee.name="";
    this.newEmployee.address="";
    this.newEmployee.salary=0;
  },
  (errror)=>{
    console.log(errror)
  }
  );
}
editClick(data:number)
{
  this.editEmployee.id=this.employeeList[data].id;
  this.editEmployee.name=this.employeeList[data].name;
  this.editEmployee.address=this.employeeList[data].address;
  this.editEmployee.salary=this.employeeList[data].salary;
}
updateClick()
{
  this.employeeService.updateEmployee(this.editEmployee).subscribe(

    (Response)=>{
      alert('data updated')
      this.getAll;

    },
    (error)=>{
      console.log(error)
    }
    ); 
}
deleteClick(i:number)
{
  let ans=confirm('want to delete data')
  if(!ans) return;
  let id=this.employeeList[i].id;
  this.employeeService.deleteEmployee(id).subscribe(

(response)=>{
  alert('data deleted')
  this.getAll();
},
(error)=>{
  console.log(error)
}
);
}
}
