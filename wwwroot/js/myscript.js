window.DotNetFunctions = {
    runPythonScript: function () {
        DotNet.invokeMethodAsync("EMS", "RunPythonScript");
    }
};
