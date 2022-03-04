﻿Scaffolding has generated all the files and added the required dependencies.
https://localhost:44372/api/admin/catalog/brands/GetPaginationList
https://localhost:44374/Admin/Brands/Index
However the Application's Startup code may require additional changes for things to work end to end.
Add the following code to the Configure method in your Application's Startup class if not already done:

        app.UseEndpoints(endpoints =>
        {
          endpoints.MapControllerRoute(
            name : "areas",
            pattern : "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );
        });


 @*<div class="row">
                <div class="col-md-6 col-xl-3">
                    <div class="card-box tilebox-one">
                        <i class="icon-layers float-right m-0 h2 text-muted"></i>
                        <h6 class="text-muted text-uppercase mt-0">Orders</h6>
                        <h3 class="my-3" data-plugin="counterup">1,587</h3>
                        <span class="badge badge-success mr-1"> +11% </span> <span class="text-muted">From previous period</span>
                    </div>
                </div>

                <div class="col-md-6 col-xl-3">
                    <div class="card-box tilebox-one">
                        <i class="icon-paypal float-right m-0 h2 text-muted"></i>
                        <h6 class="text-muted text-uppercase mt-0">Revenue</h6>
                        <h3 class="my-3">$<span data-plugin="counterup">46,782</span></h3>
                        <span class="badge badge-danger mr-1"> -29% </span> <span class="text-muted">From previous period</span>
                    </div>
                </div>

                <div class="col-md-6 col-xl-3">
                    <div class="card-box tilebox-one">
                        <i class="icon-chart float-right m-0 h2 text-muted"></i>
                        <h6 class="text-muted text-uppercase mt-0">Average Price</h6>
                        <h3 class="my-3">$<span data-plugin="counterup">15.9</span></h3>
                        <span class="badge badge-pink mr-1"> 0% </span> <span class="text-muted">From previous period</span>
                    </div>
                </div>

                <div class="col-md-6 col-xl-3">
                    <div class="card-box tilebox-one">
                        <i class="icon-rocket float-right m-0 h2 text-muted"></i>
                        <h6 class="text-muted text-uppercase mt-0">Product Sold</h6>
                        <h3 class="my-3" data-plugin="counterup">1,890</h3>
                        <span class="badge badge-warning mr-1"> +89% </span> <span class="text-muted">Last year</span>
                    </div>
                </div>
            </div>*@
            <!-- end row -->


            <!--<div class="row">
                <div class="col-lg-6 col-xl-8">
                    <div class="card-box">
                        <h4 class="header-title mb-3">Sales Statistics</h4>

                        <div class="text-center">
                            <ul class="list-inline chart-detail-list mb-0">
                                <li class="list-inline-item">
                                    <h6 class="text-info"><i class="mdi mdi-circle-outline mr-1"></i>Series A</h6>
                                </li>
                                <li class="list-inline-item">
                                    <h6 class="text-success"><i class="mdi mdi-triangle-outline mr-1"></i>Series B</h6>
                                </li>
                                <li class="list-inline-item">
                                    <h6 class="text-muted"><i class="mdi mdi-square-outline mr-1"></i>Series C</h6>
                                </li>
                            </ul>
                        </div>

                        <div id="morris-bar-stacked" class="morris-chart" style="height: 320px;"></div>

                    </div>
                </div>-->
                <!-- end col-->

                <!--<div class="col-lg-6 col-xl-4">
                    <div class="card-box">
                        <h4 class="header-title mb-3">Trends Monthly</h4>

                        <div class="text-center mb-3">
                            <div class="btn-group" role="group" aria-label="Basic example">
                                <button type="button" class="btn btn-sm btn-secondary">Today</button>
                                <button type="button" class="btn btn-sm btn-secondary">This Week</button>
                                <button type="button" class="btn btn-sm btn-secondary">Last Week</button>
                            </div>
                        </div>

                        <div id="morris-donut-example" class="morris-chart" style="height: 268px;"></div>

                        <div class="text-center">
                            <ul class="list-inline chart-detail-list mb-0 mt-2">
                                <li class="list-inline-item">
                                    <h6 class="text-info"><i class="mdi mdi-circle-outline mr-1"></i>English</h6>
                                </li>
                                <li class="list-inline-item">
                                    <h6 class="text-success"><i class="mdi mdi-triangle-outline mr-1"></i>Italian</h6>
                                </li>
                                <li class="list-inline-item">
                                    <h6 class="text-muted"><i class="mdi mdi-square-outline mr-1"></i>French</h6>
                                </li>
                            </ul>
                        </div>

                    </div>
                </div>-->
                <!-- end col-->
            <!--</div>-->
            <!-- end row -->


            <!--<div class="row">
                <div class="col-xl-7">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="card-box">
                                <h4 class="header-title mb-3">Inbox</h4>

                                <div class="inbox-widget slimscroll" style="max-height: 324px;">
                                    <a href="#">
                                        <div class="inbox-item">
                                            <div class="inbox-item-img"><img src="~\Admin\assets\images\users\avatar-1.jpg" class="rounded-circle" alt=""></div>
                                            <p class="inbox-item-author">Chadengle</p>
                                            <p class="inbox-item-text">Hey! there I'm available...</p>
                                            <p class="inbox-item-date">13:40 PM</p>
                                        </div>
                                    </a>
                                    <a href="#">
                                        <div class="inbox-item">
                                            <div class="inbox-item-img"><img src="~\Admin\assets\images\users\avatar-2.jpg" class="rounded-circle" alt=""></div>
                                            <p class="inbox-item-author">Tomaslau</p>
                                            <p class="inbox-item-text text-truncate">I've finished it! See you so...</p>
                                            <p class="inbox-item-date">13:34 PM</p>
                                        </div>
                                    </a>
                                    <a href="#">
                                        <div class="inbox-item">
                                            <div class="inbox-item-img"><img src="~\Admin\assets\images\users\avatar-3.jpg" class="rounded-circle" alt=""></div>
                                            <p class="inbox-item-author">Stillnotdavid</p>
                                            <p class="inbox-item-text">This theme is awesome!</p>
                                            <p class="inbox-item-date">13:17 PM</p>
                                        </div>
                                    </a>
                                    <a href="#">
                                        <div class="inbox-item">
                                            <div class="inbox-item-img"><img src="assets\images\users\avatar-4.jpg" class="rounded-circle" alt=""></div>
                                            <p class="inbox-item-author">Kurafire</p>
                                            <p class="inbox-item-text">Nice to meet you</p>
                                            <p class="inbox-item-date">12:20 PM</p>
                                        </div>
                                    </a>
                                    <a href="#">
                                        <div class="inbox-item">
                                            <div class="inbox-item-img"><img src="~\Admin\assets\images\users\avatar-5.jpg" class="rounded-circle" alt=""></div>
                                            <p class="inbox-item-author">Shahedk</p>
                                            <p class="inbox-item-text">Hey! there I'm available...</p>
                                            <p class="inbox-item-date">10:15 AM</p>
                                        </div>
                                    </a>
                                    <a href="#">
                                        <div class="inbox-item">
                                            <div class="inbox-item-img"><img src="~\Admin\assets\images\users\avatar-6.jpg" class="rounded-circle" alt=""></div>
                                            <p class="inbox-item-author">Adhamdannaway</p>
                                            <p class="inbox-item-text">This theme is awesome!</p>
                                            <p class="inbox-item-date">9:56 AM</p>
                                        </div>
                                    </a>
                                    <a href="#">
                                        <div class="inbox-item">
                                            <div class="inbox-item-img"><img src="~\Admin\assets\images\users\avatar-8.jpg" class="rounded-circle" alt=""></div>
                                            <p class="inbox-item-author">Arashasghari</p>
                                            <p class="inbox-item-text">Hey! there I'm available...</p>
                                            <p class="inbox-item-date">10:15 AM</p>
                                        </div>
                                    </a>
                                    <a href="#">
                                        <div class="inbox-item">
                                            <div class="inbox-item-img"><img src="~\Admin\assets\images\users\avatar-9.jpg" class="rounded-circle" alt=""></div>
                                            <p class="inbox-item-author">Joshaustin</p>
                                            <p class="inbox-item-text">I've finished it! See you so...</p>
                                            <p class="inbox-item-date">9:56 AM</p>
                                        </div>
                                    </a>
                                </div>

                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="card-box">
                                <h4 class="header-title mb-3">Sales Statistics</h4>

                                <p class="font-weight-semibold mb-3">iMacs <span class="text-danger float-right"><b>78%</b></span></p>
                                <div class="progress" style="height: 10px;">
                                    <div class="progress-bar progress-bar-striped bg-danger" role="progressbar" style="width: 78%" aria-valuenow="78" aria-valuemin="0" aria-valuemax="78"></div>
                                </div>
                            </div>

                            <div class="card-box">
                                <h4 class="header-title mb-3">Monthly Sales</h4>

                                <p class="font-weight-semibold mb-2">Macbooks <span class="text-success float-right"><b>25%</b></span></p>
                                <div class="progress" style="height: 10px;">
                                    <div class="progress-bar progress-bar-striped bg-success" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
                                </div>
                            </div>

                            <div class="card-box">
                                <h4 class="header-title mb-3">Daily Sales</h4>

                                <p class="font-weight-semibold mb-2">Mobiles <span class="text-warning float-right"><b>75%</b></span></p>
                                <div class="progress" style="height: 10px;">
                                    <div class="progress-bar progress-bar-striped bg-warning" role="progressbar" style="width: 75%" aria-valuenow="75" aria-valuemin="0" aria-valuemax="100"></div>
                                </div>
                            </div>

                        </div>

                    </div>
                </div>-->
                <!-- end col-->

                <!--<div class="col-xl-5">
                    <div class="card-box">

                        <h4 class="header-title mb-3">Top Contracts</h4>

                        <div class="table-responsive">
                            <table class="table table-bordered table-nowrap mb-0">
                                <thead>
                                    <tr>
                                        <th>Company</th>
                                        <th>Start Date</th>
                                        <th>End Date</th>
                                        <th>Status</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <th class="text-muted">Apple Technology</th>
                                        <td>20/02/2014</td>
                                        <td>19/02/2020</td>
                                        <td><span class="badge badge-success">Paid</span></td>
                                    </tr>
                                    <tr>
                                        <th class="text-muted">Envato Pty Ltd.</th>
                                        <td>20/02/2014</td>
                                        <td>19/02/2020</td>
                                        <td><span class="badge badge-danger">Unpaid</span></td>
                                    </tr>
                                    <tr>
                                        <th class="text-muted">Dribbble LLC.</th>
                                        <td>20/02/2014</td>
                                        <td>19/02/2020</td>
                                        <td><span class="badge badge-success">Paid</span></td>
                                    </tr>
                                    <tr>
                                        <th class="text-muted">Adobe Family</th>
                                        <td>20/02/2014</td>
                                        <td>19/02/2020</td>
                                        <td><span class="badge badge-success">Paid</span></td>
                                    </tr>
                                    <tr>
                                        <th class="text-muted">Apple Technology</th>
                                        <td>20/02/2014</td>
                                        <td>19/02/2020</td>
                                        <td><span class="badge badge-danger">Unpaid</span></td>
                                    </tr>
                                    <tr>
                                        <th class="text-muted">Envato Pty Ltd.</th>
                                        <td>20/02/2014</td>
                                        <td>19/02/2020</td>
                                        <td><span class="badge badge-success">Paid</span></td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>-->
                <!-- end col-->

            <!--</div>-->
            <!-- end row -->