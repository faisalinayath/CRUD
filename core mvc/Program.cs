        <form method="post" asp-controller="Properties" asp-action="Create">
            <div class="user-box">
                <input type="text"  required="">
                <label>Name Of The Property</label>
            </div>
            <div class="user-box">
                <input type="text"  required="">
                <label>Price</label>
            </div>
            <div class="user-box">
                <input type="text" required="">
                <label>Description</label>
            </div>
            <div class="user-box">
                <input type="file" id="img" name="img" accept="image/*">
              
            </div>
              <div class="user-box">
                <input type="text" required="" >
                <label>Seller Name</label>

            </div>
            <div class="user-box">
                <input type="text" required="" >
                <label>Seller Phone NUmber</label>

            </div>
            <div class="user-box">
                <input type="text" required="">
                <label>Seller Email Id</label>

                
            </div>
            <a href="#">
                <span></span>
                <span></span>
                <span></span>
                Submit
            </a>

            <a style="float:right" asp-controller="Properties" asp-action="index">
                <span></span>
                <span></span>
                <span></span>
                Return
            </a>
        </form>
