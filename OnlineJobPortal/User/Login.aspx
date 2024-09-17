<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OnlineJobPortal.User.Login" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section>
        <div class="container pt-50 pb-40">
            <div class="row">

                <div class="col-12 pb-100">
                    <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
                </div>

                <div class="col-12">
                    <h2 class="contact-title">Sign In</h2>
                </div>
                <div class="col-lg-8">
                    <div class="form-contact contact_form">
                        <div class="row">

                            <div class="col-10">
                                <di class="form-group">
                                    <label>Username</label>
                                    <asp:TextBox required="true" ID="txtUserName" runat="server" CssClass="form-control" placeholder="Enter Username"></asp:TextBox>

                                </di>
                            </div>
                            <div class="col-10">
                                <div class="form-group">
                                    <label>Password</label>
                                    <asp:TextBox required="true" ID="LoginPassword" runat="server" CssClass="form-control" placeholder="Enter a Password" TextMode="Password"></asp:TextBox>

                                </div>
                            </div>

                            <div class="col-6">
                                <div class="form-group">
                                    <label>Login Type</label>
                                    <asp:DropDownList ID="ddlLogin" runat="server" CssClass="form-conrol w-100">
                                        <asp:ListItem Value="0">Select Login Type</asp:ListItem>
                                        <asp:ListItem>Admin</asp:ListItem>
                                        <asp:ListItem>User</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ControlToValidate="ddlLogin" ID="RequiredFieldValidator1" runat="server"
                                        ErrorMessage="Login is required" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"
                                        Font-Size="Small" InitialValue="0">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="form-group mt-3">

                                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="button button-contactForm boxed-btn m-4"
                                    OnClick="btnLogin_Click" />
                                <span class="clickLink"><a href="../User/Register.aspx">New Here? Click here to SignUp..</a></span>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
