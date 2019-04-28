# P.Pager

## Build Status

[![Build Status](https://dev.azure.com/PuffinWeb/P.Pager/_apis/build/status/PuffinWeb.P.Pager?branchName=master)](https://dev.azure.com/PuffinWeb/P.Pager/_build/latest?definitionId=3&branchName=master)

## What is this?
P.Pager is Lightweight package for easily paging through any IEnumerable/IQueryable, chop it up into "pages", and grab a specific "page" by an index. It supports Web projects, Winforms, WPF, Window Phone, Silverlight and other .NET projects. It is default configured to **> Bootstrap 3.3.1**.

## How do I use it?
### Installation
#### .Net Framework ( > 4.5.2)
Install [P.Pager.Mvc](https://www.nuget.org/packages/P.Pager.Mvc/) via [NuGet](http://nuget.org). This will install [P.Pager](https://www.nuget.org/packages/P.Pager/) automatically.
```
Install-Package P.Pager.Mvc -Version 1.4.0
```
#### .Net Core (.NET Standard 2.0)
Install [P.Pager.Mvc.Core](https://www.nuget.org/packages/P.Pager.Mvc.Core/) via [NuGet](http://nuget.org). This will install [P.Pager](https://www.nuget.org/packages/P.Pager/) automatically.
```
Install-Package P.Pager.Mvc.Core -Version 1.4.0
```

### After that
1. In your controller code, call **ToPagerList** off of your IEnumerable/IQueryable passing in the page size.
```csharp

public class HomeController : Controller
{
    readonly DemoData _data;
    public HomeController()
    {
        _data = new DemoData();
    }

    public ActionResult Index(int page = 1, int pageSize = 10)
    {
        var pager = _data.GetMembers().ToPagerList(page, pageSize);
        // will only contain 10 members max because of the pageSize.
        return View(pager);
    }
}       
```

2. Pass the result of **ToPagerList** to your view where you can enumerate over it - its still an IEnumerable, but only contains a child of the original data.

3. Call **Html.Pager**, passing in the instance of the Pager and a function that will generate URLs for each page to see a paging control.

```csharp
//Default Pager options
@Html.Pager((IPager)Model, page => Url.Action("Index", new { page }))
```
![alt text](https://raw.githubusercontent.com/PuffinWeb/P.Pager/master/img/1.default.PNG)

## PagerOptions
Default options for rendering pagination.


## PrePagerOptions
1. Minimal Pager
```csharp
//Shows only the Previous and Next links.
@Html.Pager((IPager)Model, page => Url.Action("Index", new { page }), PrePagerOptions.Minimal)
```
![alt text](https://raw.githubusercontent.com/PuffinWeb/P.Pager/master/img/2.%20minimal.PNG)

2. Minimal Pager with Pager Text (Page Count Text)
```csharp
//Shows Previous and Next links along with current page number and total number of pages in pager.
@Html.Pager((IPager)Model, page => Url.Action("Index", new { page }), PrePagerOptions.MinimalWithPagerText)
```
![alt text](https://raw.githubusercontent.com/PuffinWeb/P.Pager/master/img/3.minimalpagecount.PNG)

3. Minimal Pager with entries text (Item Count Text)
```csharp
//Shows Previous and Next links along with index of start and last item and total entries in pager.
@Html.Pager((IPager)Model, page => Url.Action("Index", new { page }), PrePagerOptions.MinimalWithEntriesText)
```
![alt text](https://raw.githubusercontent.com/PuffinWeb/P.Pager/master/img/4.minimalwithentries.PNG)

4. Classic Pager <small>(always shows Previous/Next links, but sometimes they are disabled)</small>
```csharp
//Shows Previous and Next page always with default, 5 pages.
@Html.Pager((IPager)Model, page => Url.Action("Index", new { page }), PrePagerOptions.ClassicPager)
```
6. Classic Pager <small>(Classic Pager with First and Last links, but sometimes they are disabled)</small>
```csharp
//Shows Last, First, Previous and Next page always with default, 5 pages. 
@Html.Pager((IPager)Model, page => Url.Action("Index", new { page }), PrePagerOptions.ClassicPagerWithFirstAndLastPages)
```
## License
Licensed under the [MIT License](https://github.com/PuffinWeb/P.Pager/blob/master/LICENSE).
