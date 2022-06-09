# BannedApplicationUseageManager
一体机使用限制(浏览器主要) + 语文文言翻译午间自动关机 + 数学午间讲题抽人

# 解锁密码
![Image text](https://github.com/LunaroakF/Images/blob/master/BannedApplicationUseageManager/v1.1.10%201.png)  
![Image text](https://github.com/LunaroakF/Images/blob/master/BannedApplicationUseageManager/v1.2.1%202.png)  
![Image text](https://github.com/LunaroakF/Images/blob/master/BannedApplicationUseageManager/v1.2.1%201.png)  
- 在Bools.cs中进行修改，默认为123456

# 支持移动存储介质解锁  
使用UTF-8（或者记事本写入密码至txt文件 然后重命名为DAKey文件[无后缀名]）存储至移动设备根目录即可

# 数学抽人  
在与运行程序同目录下`BAUM_Settings`文件夹中(见Release压缩包中)存在`students_table.inf`与`math_history.inf`文件  
`students_table.inf`中第一条`6-8-8-9-9-8-8-40`含义为  
- 6：一共有6排座位  
- 8：第一排有8座
- 8：第二排有8座
- 9：第三排有9座
- 9：第四排有9座
- 8：第五排有8座
- 8：第六排有8座
- 40：不重复抽中同一人次数为40  
若需要添加排数则直接修改第一个6以及在8-40之间添加新排数座位数  

该类信息务必使用`-`减号隔开  
在`students_table.inf`文件中第二条以及以后则从第一排第一座，第一排第二座......以此类推输入信息，就用Windows自带记事本即可  
