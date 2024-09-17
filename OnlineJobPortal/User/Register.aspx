<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="OnlineJobPortal.User.Register" EnableEventValidation="false"%>

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
                    <h2 class="contact-title">Sign Up</h2>
                </div>
                <div class="col-lg-8">
                    <div class="form-contact contact_form">
                        <div class="row">
                            <div class="col-12">
                                <h5>Login Information</h5>
                            </div>
                            <div class="col-12">
                                <div class="form-group">
                                    <label>Username</label>
                                    <asp:TextBox required="true" ID="txtUserName" runat="server" CssClass="form-control" placeholder="Enter Username"></asp:TextBox>

                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <label>Password</label>
                                    <asp:TextBox required="true" ID="Password" runat="server" CssClass="form-control" placeholder="Enter a Password" TextMode="Password"></asp:TextBox>

                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <label>Confirm Password</label>
                                    <asp:TextBox required="true" ID="ConfirmPass" runat="server" CssClass="form-control" placeholder="Confirm your Password" TextMode="Password"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Passwords do not match"
                                        ControlToCompare="Password" ControlToValidate="ConfirmPass" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small"></asp:CompareValidator>

                                </div>
                            </div>


                            <div class="col-12">
                                <h5>Personal Information</h5>
                            </div>


                            <div class="col-12">
                                <div class="form-group">
                                    <label>Full Name</label>
                                    <asp:TextBox required="true" ID="txtFullName" runat="server" CssClass="form-control" placeholder="Enter Full Name"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtFullName"
                                        ErrorMessage="InValid Contact Number" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"
                                        Font-Size="Small" ValidationExpression="^[a-zA-Z\s]+$"></asp:RegularExpressionValidator>
                                </div>
                            </div>


                            <div class="col-12">
                                <div class="form-group">
                                    <label>Address</label>

                                    <asp:TextBox required="true" ID="txtAddress" runat="server" CssClass="form-control"
                                        placeholder="Enter Address" TextMode="MultiLine">
                                    </asp:TextBox>

                                </div>
                            </div>


                            <div class="col-12">
                                <div class="form-group">
                                    <label>Contact</label>

                                    <asp:TextBox
                                        required="true" ID="txtContact" runat="server" CssClass="form-control" placeholder="Enter Contact Number">
                                    </asp:TextBox>

                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtContact"
                                        ErrorMessage="InValid Contact Number" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"
                                        Font-Size="Small" ValidationExpression="^[0-9]{10}$">
                                    </asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="col-12">
                                <div class="form-group">
                                    <label>Email</label>
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter Email Address" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-12">
                                <div class="form-group">
                                    <label>Country</label>

                                    <asp:DropDownList ID="ddlCountry" runat="server" DataSourceID="SqlDataSource1" CssClass="form-control w-100"
                                        AppendDataBoundItems="true" DataTextField="CountryName" DataValueField="CountryName">
                                        <asp:ListItem Value="0">Select Country</asp:ListItem>
                                    </asp:DropDownList>

                                    <asp:RequiredFieldValidator ControlToValidate="ddlCountry" ID="RequiredFieldValidator1" runat="server"
                                        ErrorMessage="Country is required" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"
                                        Font-Size="Small" InitialValue="0">
                                     </asp:RequiredFieldValidator>

                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnSt %>"
                                        SelectCommand="SELECT [CountryName] FROM [Country]">
                                    </asp:SqlDataSource>

                                </div>
                            </div>

                        </div>
                        <div class="form-group mt-3">

                            <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="button button-contactForm boxed-btn m-4" 
                                OnClick="btnRegister_Click" />
                            <span class="clickLink"><a href="../User/Login.aspx">Already Registered? Click here to Login..</a></span>
                        </div>
                    </div>

                </div>
            </div>

        </div>
    </section>
</asp:Content>
