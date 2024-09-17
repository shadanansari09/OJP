<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddJobs.aspx.cs" Inherits="OnlineJobPortal.Admin.AddJobs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="background-image: url('../images/bgs.jpeg'); width: 100%; height: 720px; background-repeat: no-repeat; background-size: cover; background-attachment: fixed;">

        <div class="container pt-4 pb-4">
            <%--<div>
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>--%>

            <div class="btn-toolbar justify-content-between mb-3 ">
                <div class="btn-group">
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </div>

                <div class="input-group h-25">
                    <asp:HyperLink ID="backLink" runat="server" NavigateUrl="~/Admin/JobList.aspx" CssClass="btn btn-secondary" 
                        Visible="false" > <-Back</asp:HyperLink>
                </div>
            </div>

            <h3 class="text-center"><%Response.Write(Session["title"]); %></h3>


            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-6 pt-3">
                    <label for="txtJobTitle" style="font-weight: 600">Job Title</label>
                    <asp:TextBox ID="txtJobTitle" runat="server" CssClass="form-control" placeholder="eg. Web Developer"></asp:TextBox>
                </div>

                <div class="col-md-6 pt-3">
                    <label for="txtVacancies" style="font-weight: 600">Vacancies</label>
                    <asp:TextBox ID="txtVacancies" runat="server" CssClass="form-control"
                        placeholder="enter number of vacancies" TextMode="Number" Required="true"></asp:TextBox>
                </div>
            </div>


            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-12 pt-3">
                    <label for="txtDescription" style="font-weight: 600">Description</label>
                    <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control"
                        placeholder="Enter Job Description" TextMode="MultiLine" Required="true"></asp:TextBox>
                </div>
            </div>

            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-6 pt-3">
                    <label for="txtQualification" style="font-weight: 600">Qualification</label>
                    <asp:TextBox ID="txtQualification" runat="server" CssClass="form-control" placeholder="Ex. MCA,BTech, BCA, MBA" Required="true"></asp:TextBox>
                </div>

                <div class="col-md-6 pt-3">
                    <label for="txtExperience" style="font-weight: 600">Experience</label>
                    <asp:TextBox ID="txtExperience" runat="server" CssClass="form-control"
                        placeholder="Ex. 0-1" Required="true"></asp:TextBox>
                </div>
            </div>

            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-6 pt-3">
                    <label for="txtKeySkills" style="font-weight: 600">Key Skills</label>
                    <asp:TextBox ID="txtKeySkills" runat="server" CssClass="form-control"
                        placeholder="Enter Required Skills" Required="true" TextMode="MultiLine"></asp:TextBox>
                </div>

                <div class="col-md-6 pt-3">
                    <label for="txtDeadline" style="font-weight: 600">Last date to apply</label>
                    <asp:TextBox ID="txtDeadline" runat="server" CssClass="form-control"
                        placeholder="Enter Last date to apply" TextMode="Date" Required="true"></asp:TextBox>
                </div>
            </div>


            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-6 pt-3">
                    <label for="txtSalary" style="font-weight: 600">Salary</label>
                    <asp:TextBox ID="txtSalary" runat="server" CssClass="form-control"
                        placeholder="Ex. 25000/Month or 3L per Annum" Required="true"></asp:TextBox>
                </div>

                <div class="col-md-6 pt-3">
                    <label for="ddlJobType" style="font-weight: 600">Job Type</label>
                    <asp:DropDownList ID="ddlJobType" runat="server" CssClass="form-control">
                        <asp:ListItem Value="0">Select Job Type</asp:ListItem>
                        <asp:ListItem>Full Time</asp:ListItem>
                        <asp:ListItem>Part Time</asp:ListItem>
                        <asp:ListItem>Freelance</asp:ListItem>
                        <asp:ListItem>Internship</asp:ListItem>
                        <asp:ListItem>Work from home</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlJobType"
                        CssClass="form-control" ForeColor="Red" Display="Dynamic"
                        ErrorMessage="Job Type is required" SetFocusOnError="true">
                    </asp:RequiredFieldValidator>
                </div>
            </div>


            <h3 class="pt-5 pb-5 text-center">Company Details & Contact Info</h3>
            <div class="row mr-lg-5 ml-lg-5 mb-3">



                <div class="col-md-6 pt-3">
                    <label for="txtCompany" style="font-weight: 600">Company</label>
                    <asp:TextBox ID="txtCompany" runat="server" CssClass="form-control"
                        placeholder="Enter Company Name" Required="true"></asp:TextBox>
                </div>

                <div class="col-md-6 pt-3">
                    <label for="ddlCompanyLogo" style="font-weight: 600">Company Logo</label>
                    <asp:FileUpload ID="fuCompanyLogo" runat="server" CssClass="form-control" ToolTip=".jpg, .jpeg, .png extension only" />
                </div>

            </div>

            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-6 pt-3">
                    <label for="txtWebsite" style="font-weight: 600">Website</label>
                    <asp:TextBox ID="txtWebsite" runat="server" CssClass="form-control"
                        placeholder="Enter Website URL" TextMode="url"></asp:TextBox>
                </div>

                <div class="col-md-6 pt-3">
                    <label for="txtEmail" style="font-weight: 600">Email</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"
                        placeholder="Enter Email Address" TextMode="Email"></asp:TextBox>
                </div>
            </div>

            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-12 pt-3">
                    <label for="txtAddress" style="font-weight: 600">Address</label>
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"
                        placeholder="Enter Company's Address" TextMode="MultiLine" Required="true"></asp:TextBox>
                </div>
            </div>


            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-6 pt-3">
                    <label for="txtCountry" style="font-weight: 600">Country</label>
                    <asp:DropDownList ID="ddlCountry" runat="server" DataSourceID="SqlDataSource1" CssClass="form-control w-100"
                        AppendDataBoundItems="true" DataTextField="CountryName" DataValueField="CountryName">
                        <asp:ListItem Value="0">Select Country</asp:ListItem>
                    </asp:DropDownList>

                    <asp:RequiredFieldValidator ControlToValidate="ddlCountry" ID="RequiredFieldValidator2" runat="server"
                        ErrorMessage="Country is required" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"
                        Font-Size="Small" InitialValue="0">
                    </asp:RequiredFieldValidator>

                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnSt %>"
                        SelectCommand="SELECT [CountryName] FROM [Country]"></asp:SqlDataSource>
                </div>

                <div class="col-md-6 pt-3">
                    <label for="txtState" style="font-weight: 600">State</label>
                    <asp:TextBox ID="txtState" runat="server" CssClass="form-control"
                        placeholder="Enter State" Required="true"></asp:TextBox>
                </div>


            </div>

            <div class="row mr-lg-5 ml-lg-5 mb-3 pt-4 ">
                <div class="col-md-3 col-md-offset-2 mb-3">
                    <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary btn-block"
                        BackColor="#7200cf" Text="Add Job" OnClick="btnAdd_Click" />
                </div>
            </div>


        </div>
    </div>

</asp:Content>
