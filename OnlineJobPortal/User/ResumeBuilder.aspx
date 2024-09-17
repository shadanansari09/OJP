<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="ResumeBuilder.aspx.cs" EnableEventValidation="false" Inherits="OnlineJobPortal.User.ResumeBuilder" %>

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
                    <h2 class="contact-title">Build Resume</h2>
                </div>
                <div class="col-lg-12">
                    <div class="form-contact contact_form">
                        <div class="row">

                            <div class="col-12">
                                <h5>Personal Information</h5>
                            </div>

                            <div class="col-md-6 col-sm-12">
                                <div class="form-group">
                                    <label>Full Name</label>
                                    <asp:TextBox required="true" ID="txtFullName" runat="server" CssClass="form-control" placeholder="Enter Full Name"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtFullName"
                                        ErrorMessage="InValid Contact Number" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"
                                        Font-Size="Small" ValidationExpression="^[a-zA-Z\s]+$"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="col-md-6 col-sm-12">
                                <div class="form-group">
                                    <label>Username</label>
                                    <asp:TextBox required="true" ID="txtUserName" runat="server" CssClass="form-control" placeholder="Enter Username"></asp:TextBox>
                                </div>
                            </div>


                            <div class="col-md-6 col-sm-12">
                                <div class="form-group">
                                    <label>Address</label>

                                    <asp:TextBox required="true" ID="txtAddress" runat="server" CssClass="form-control"
                                        placeholder="Enter Address" TextMode="MultiLine">
                                    </asp:TextBox>

                                </div>
                            </div>


                            <div class="col-md-6 col-sm-12">
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

                            <div class="col-md-6 col-sm-12">
                                <div class="form-group">
                                    <label>Email</label>
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter Email Address" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6 col-sm-12">
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
                                        SelectCommand="SELECT [CountryName] FROM [Country]"></asp:SqlDataSource>

                                </div>
                            </div>


                            <div class="col-12 pt-4">
                                <h5>Education/Resume Information</h5>
                            </div>

                            <div class="col-md-6 col-sm-12">
                                <div class="form-group">
                                    <label>10th Percentage</label>
                                    <asp:TextBox ID="txtTenth" runat="server" CssClass="form-control" placeholder="ex. 69%" Required="true"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6 col-sm-12">
                                <div class="form-group">
                                    <label>12th Percentage</label>
                                    <asp:TextBox ID="txtTwelfth" runat="server" CssClass="form-control" placeholder="ex. 69%" Required="true"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6 col-sm-12">
                                <div class="form-group">
                                    <label>UG Pointer/Grade</label>
                                    <asp:TextBox ID="txtUG" runat="server" CssClass="form-control" placeholder="CGPA" Required="true"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6 col-sm-12">
                                <div class="form-group">
                                    <label>PG Pointer/Grade</label>
                                    <asp:TextBox ID="txtPG" runat="server" CssClass="form-control" placeholder="CGPA"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6 col-sm-12">
                                <div class="form-group">
                                    <label>PhD Pointer/Grade</label>
                                    <asp:TextBox ID="txtPhd" runat="server" CssClass="form-control" placeholder="CGPA"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6 col-sm-12">
                                <div class="form-group">
                                    <label>Job Profile</label>
                                    <asp:TextBox ID="txtWork" runat="server" CssClass="form-control" placeholder="Job Profile"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6 col-sm-12">
                                <div class="form-group">
                                    <label>Work Experience</label>
                                    <asp:TextBox ID="txtExperience" runat="server" CssClass="form-control" placeholder="Experience in Years"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6 col-sm-12">
                                <div class="form-group">
                                    <label>Resume</label>
                                    <asp:FileUpload ID="fuResume" runat="server" CssClass="form-control pt-2" ToolTip=".docx,.doc,.pdf extensions only"/>
                                </div>
                            </div>

                        </div>
                        <div class="form-group mt-3">

                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="button button-contactForm boxed-btn mr-4"
                                OnClick="btnUpdate_Click" />
                           
                        </div>
                    </div>

                </div>
            </div>

        </div>
    </section>
</asp:Content>
