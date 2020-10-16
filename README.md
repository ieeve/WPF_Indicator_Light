**极简，只有四个点，通过不同的颜色和闪烁来表示设备的运行状态。**

可自由放大，缩小，和拉伸到你认为合适的尺寸。

github地址：[https://github.com/ieeve/WPF\_Indicator\_Light](https://github.com/ieeve/WPF_Indicator_Light)

1\. 设备停止状态

![](https://img2020.cnblogs.com/blog/1133037/202010/1133037-20201017001340680-950995033.png)

2\. 设备正常运行状态

![](https://img2020.cnblogs.com/blog/1133037/202010/1133037-20201017001408260-1598457393.gif)

3\. 设备警告

![](https://img2020.cnblogs.com/blog/1133037/202010/1133037-20201017001430868-1564722501.gif)

4\. 设备错误

![](https://img2020.cnblogs.com/blog/1133037/202010/1133037-20201017001453647-985624055.gif)

5.严重错误

![](https://img2020.cnblogs.com/blog/1133037/202010/1133037-20201017001510707-1009466956.gif)

**设计要点：**

使用Border做了一个圆形，然后在外面包了一个ViewBox，使控件可以自由缩放。