<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AspCrudWithProcedureAndAjax._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <div class="container">
      
        <div class="row">
            <div class="col-md-4">
                  <h1>Make Note</h1>
                    <div class="form-floating mb-3">
              <input type="text" class="form-control" id="title" placeholder="Title">
               <input type="hidden" class="form-control" id="id" >
              <label for="floatingInput">Title</label>
            </div>
            <div class="form-floating">
              <textarea class="form-control" placeholder="Leave a comment here" id="note" style="height: 100px"></textarea>
              <label for="floatingTextarea2">Note</label>
            </div>
               <div class="d-grid gap-2">
  <button class="btn btn-danger mt-3 createnote" type="button">Add</button>
  <button class="btn btn-danger mt-3 updatenote d-none" type="button">Update</button>
</div>
            </div>
            <div class="col-md-4">
           <h1>Today Quote</h1>
            </div>
        </div>

        </div>
            </div>

   <div class="container">
        <div class="row mt-4" id="htmlcard">
    </div>
   </div>

</asp:Content>
