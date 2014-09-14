function setSeletedFile(selectedFile) {
    document.getElementById("fileInput").value = selectedFile.value.replace(/^.*[\\\/]/, '');
};
