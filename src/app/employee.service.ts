import { Injectable } from '@angular/core';
import{HttpClient}from '@angular/common/http';
import{Observable}from 'rxjs'
import { Employee } from './employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private httpclient:HttpClient) { }

  getAllEmployee():Observable<any>
{
return this.httpclient.get<any>("https://localhost:44361/api/Employee");
}
saveEmployee(newEmployee:Employee):Observable<Employee>
{
  return this.httpclient.post<Employee>
  ("https://localhost:44361/api/Employee",newEmployee);
}
updateEmployee(editEmployee:Employee):Observable<Employee>
{
  return this.httpclient.put<Employee>("https://localhost:44361/api/Employee",editEmployee);
}
deleteEmployee(id:Number):Observable<any>
{
  return this.httpclient.delete<any>("https://localhost:44361/api/Employee/" + id);
}
}