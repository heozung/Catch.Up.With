<?php
if(!defined('HoangXL')) exit('direct access is not allowed.');
?>
<table cellSpacing=0 cellPadding=0 width=100% align=center border=0>
	<tr class=tcat>
		<td width=10 align=center></td>
		<td>.: H o m e</td>
	</tr>
</table>
<table cellSpacing=0 cellPadding=0 width=90% align=center border=0 align=center>
	<tr>
		<td align=center><font size=3><b>Welcome<br>to</b></font><br><font color=yellow size=5>[ x G a l l e r y ]</font><br><br><hr width="70%">- Hoang XL © 2009 -<hr width="70%"></td>
	</tr>
	<tr>
		<td>
		<b class=home>[ Admin Controls ] - Trang chủ của Admin Control Panel.</b>
			<li>Giới thiệu.</li>
			<li>Hướng dẫn.</li><br>		
		<b class=home>[ Thể loại hình ] - Quản lý (thêm-sửa-xóa) thể loại hình (ảnh).</b>
			<li>Cú pháp của Database: <b>[Tên thể loại]@[đường_dẫn_tới_thư_mục_chứa hình]</b>.</li>
			<li>Ví dụ: <b>Thiên Nhiên@thiennhien@</b>, trong đó <b>Thiên Nhiên</b> là tên thể loại và sau cái <b>@</b> là thư mục chứa hình của thể loại đó - (http://your_site/<font color=yellow>photoz/</font>thiennhien). <font color=yellow>Thằng này nằm trong phần cấu hình (xl_config.php và admin.config.php)</font>.</li>
			<li>Kết thúc 1 dòng (thể loại) luôn là ký hiệu <b>@</b>.</li>
			<li>Không được xóa dòng trên cùng (có thể thay đổi) <b>([Ten the loai]@[thu muc chua hinh anh])</b>.</li>
			<li>Thư mục của thể loại sẽ được tạo khi upload ảnh - nếu thư mục tương ứng chưa có.</li><br>
		<b class=home>[ Hình ảnh ] - Quản lý (xem-xóa) hình (ảnh).</b>
			<li>Hình (ảnh) sẽ được sắp xếp theo thứ tự ngày upload, thằng nào mới up sẽ được xem trước và ngược lại.</li><br>
		<b class=home>[ Upload ] - Upload hình (ảnh) lên host.</b>	
			<li>Phải chọn đúng thể loại để upload.</li>
			<li>Chỉ upload các tập tin với định dạng JPEG, GIF, PNG. Cấu hình các tập tin không được Upload nằm trong tập tin admin.config.php ở phần <b>$blacklist</b>.</li>
			<li>Tập tin khi upload sẽ tự thay đổi tên để tiện sắp xếp thứ tự khi xem (view).</li>
			<li>Chỉ được upload tập tin hình (ảnh) với độ phân giải từ 1024 trở xuống.</li><br>
		<b class=home>[ Thay đổi mật mã ]</b>
			<li>Khỏi nói, mệt lắm rồi.</li>
		</td>
	</tr>
	<tr>
		<td align=center>
			<hr width="70%">- Have a fun -<hr width="70%">
		</td>
	</tr>
</table>
