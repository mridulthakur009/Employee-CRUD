<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeDetails.aspx.cs" Inherits="EmployeeDetails_3Dec_new.EmployeeDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%--<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>--%>
    <script type="text/javascript" src="https://code.jquery.com/jquery-1.8.2.js"></script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.min.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <div>
        </div>
        <h2>Welcome To DITS</h2>
        <p>
            Emp No.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label1" runat="server" class="text-primary" CssClass="text-primary" Text="Name"></asp:Label>
            :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox2" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
        </p>
        <p>
            E-mail:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox3" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
        </p>
        <p>
            Address:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox4" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
        </p>
        <p style="margin-left: 120px">
&nbsp;
            <asp:Button ID="saveButton" runat="server" BackColor="Green" ForeColor="White" Height="48px" Text="Save" Width="91px" OnClick="saveButton_Click" />
            <%--<button id="saveButton" type="button" class="btn btn-success" onclick="Add()">Save</button>--%>
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="displayButton" runat="server" BackColor="Yellow" ForeColor="Black" Height="44px" Text="Display" Width="94px" OnClick="displayButton_Click" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="updateButton" runat="server" BackColor="Blue" ForeColor="White" Height="44px" Text="Update" Width="90px" OnClick="updateButton_Click" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="deleteButton" runat="server" BackColor="Red" BorderColor="White" Font-Bold="False" ForeColor="White" Height="43px" Text="Delete" Width="89px" OnClick="deleteButton_Click" />
        </p>
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Height="238px" Width="1030px">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </form>
    <%--<script src="Scripts/employee.js"></script>--%>
    <script>

        function Add() {
            var empNo = document.getElementById("TextBox1").value;
            var name = document.getElementById("TextBox2").value;
            var email = document.getElementById("TextBox3").value;
            var address = document.getElementById("TextBox4").value;

            if (empNo && name && email && address) {
                debugger
                $.ajax({
                    type: "POST",
                    url: "EmployeeDetails.aspx/addData",
                    data: "{'empNo':'" + empNo + "','name':'" + name + "','email':'" + email + "','address':'" + address + "'}",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        let obj = data.d;
                        if (obj === true) {
                            $('#TextBox1').val('');
                            $('#TextBox2').val('');
                            $('#TextBox3').val('');
                            $('#TextBox4').val('');
                            alert("Data Saved Successfully");
                        }
                    },
                    error: function (result) {
                        alert("Error Occurred, Please Try Again");
                    }
                });
            }
            else {
                alert("Please fill all the fields! !");
                return false;
            }
        }
    </script>
</body>
</html>
