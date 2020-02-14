param ($ssocode, $appname)

$scriptPath = $MyInvocation.MyCommand.Path 
invoke-expression -Command .\myScript1.ps1 $ssocode "SteelToeManagedTasks"

cf login --sso-passcode $ssocode
$appid = cf app $appname --guid
$reason = ""


$taskName = "SayHello"
$timestamp = Get-Date -Format "yyyyMMddHHmmss"
$taskRunName = "$appname.$taskName.$timestamp"
cf run-task $appname "./ManagedTasks.WebApp runtask=$taskName taskName=$taskRunName" --name $taskRunName

$sleepInterval = 10;
$maxSleep = 40;
$totalSleep = 0;

while($totalSleep -le $maxSleep)
{
    Start-Sleep -s $sleepInterval
    Write-Output "Checking State";
    $totalSleep = $totalSleep + $sleepInterval
    $response =  cf curl "/v3/apps/$appid/tasks?names=$taskRunName"
    $JsonResponse = $response | ConvertFrom-JSON

    $state = $JsonResponse.resources.state
    if ($state -ne "RUNNING")
    {
        Write-Output "Completed Running";
        $totalSleep = $maxSleep +1
    }
}

if ($state -ne "SUCCEEDED")
{
    $reason = $JsonResponse.resources.result.failure_reason
    Write-Output $state;
    Write-Output $reason;
    Write-Output $response;
    exit 1
}
Write-Output $response

$taskName = "SayGoodBye"
$timestamp = Get-Date -Format "yyyyMMddHHmmss"
$taskRunName = "$appname.$taskName.$timestamp"
cf run-task $appname "./ManagedTasks.WebApp runtask=$taskName taskName=$taskRunName" --name $taskRunName

$sleepInterval = 10;
$maxSleep = 20;
$totalSleep = 0;

while($totalSleep -le $maxSleep)
{
    Start-Sleep -s $sleepInterval
    Write-Output "Checking State";
    $totalSleep = $totalSleep + $sleepInterval
    $response =  cf curl "/v3/apps/$appid/tasks?names=$taskRunName"
    $JsonResponse = $response | ConvertFrom-JSON

    $state = $JsonResponse.resources.state
    if ($state -ne "RUNNING")
    {
        Write-Output "Completed Running";
        $totalSleep = $maxSleep +1
    }
}

if ($state -ne "SUCCEEDED")
{
    $reason = $JsonResponse.resources.result.failure_reason
    Write-Output $state;
    Write-Output $reason;
    Write-Output $response;
    exit 1
}
Write-Output $response

$taskName = "ForceException"
$timestamp = Get-Date -Format "yyyyMMddHHmmss"
$taskRunName = "$appname.$taskName.$timestamp"
cf run-task $appname "./ManagedTasks.WebApp runtask=$taskName taskName=$taskRunName" --name $taskRunName

$sleepInterval = 10;
$maxSleep = 40;
$totalSleep = 0;

while($totalSleep -le $maxSleep)
{
    Start-Sleep -s $sleepInterval
    Write-Output "Checking State";
    $totalSleep = $totalSleep + $sleepInterval
    $response =  cf curl "/v3/apps/$appid/tasks?names=$taskRunName"
    $JsonResponse = $response | ConvertFrom-JSON

    $state = $JsonResponse.resources.state
    if ($state -ne "RUNNING")
    {
        Write-Output "Completed Running";
        $totalSleep = $maxSleep +1
    }
}

if ($state -ne "SUCCEEDED")
{
    $reason = $JsonResponse.resources.result.failure_reason
    Write-Output $state;
    Write-Output $reason;
    Write-Output $response;
    exit 1
}
Write-Output $response