const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")
    .build();

connection.on("ReceiveProgress", function (progress) {
    // 在这里更新进度条
    document.getElementById("userInput").value = progress;

    var progressBar = document.getElementById("progressBar1");
    progressBar.style.width = `${progress}%`;
    progressBar.innerHTML = `${progress}%`;

    console.log(`Progress: ${progress}%`);
});

connection.start()
    .then(function () {
        console.log("SignalR connected.");
    })
    .catch(function (err) {
        console.error(err.toString());
    });

// 启动进度更新
document.getElementById("sendButton").addEventListener("click", function (event) {
    document.getElementById("sendButton").disabled = true;
    const showProgressBar = document.getElementById("showProgressBar");
    showProgressBar.style.display = "block";
    fetch("/Home/StartProgress")
        .then(function (response) {
            if (response.ok) {
                document.getElementById("sendButton").disabled = false;
                showProgressBar.style.display = "none";
                console.log("Progress started.");
            } else {
                console.error("Failed to start progress.");
            }
        })
        .catch(function (err) {
            console.error(err.toString());
        });
    event.preventDefault();
})
