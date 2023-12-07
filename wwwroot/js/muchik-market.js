function DownloadExcel(filename, fileBase64) {
    const anchorElement = document.createElement("a");
    anchorElement.download = filename;
    anchorElement.href = "data:application/vnd.ms-excel;base64," + fileBase64;

    document.body.appendChild(anchorElement);
    anchorElement.click();
    document.body.removeChild(anchorElement);
}