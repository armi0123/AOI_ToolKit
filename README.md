# AOI ToolKit

## 中文介紹

這是一個使用 C#、WinForms 與 OpenCV 開發中的 AOI 檢測工具開發平台。

本專案主要用於研究與開發各種工業視覺檢測工具，並透過模組化設計方式，建立可重複使用與擴充的 AOI Tool Library。

與一般 AOI 軟體著重於設備整合不同，本專案更專注於影像處理演算法、檢測工具開發以及檢測流程驗證。

未來規劃將作為 AOI Platform 的檢測引擎，提供各種視覺檢測工具與演算法模組。

### 目前已完成

* ROI 編輯工具
* Sobel 邊緣檢測
* 二值化工具
* QR Code 辨識
* DataMatrix 辨識
* Tool Pipeline 基礎架構
* 檢測結果管理

### 持續開發中

* Blob 分析
* 特徵定位
* OCR 文字辨識
* 幾何量測工具
* AI 瑕疵檢測
* 缺陷分類功能

### 專案目標

* 建立可擴充的 AOI Tool Library
* 練習 OpenCV 與影像處理技術
* 研究工業 AOI 常用檢測方法
* 作為 AOI Platform 的檢測核心模組

----------

## English Introduction

AOI ToolKit is a vision inspection tool development project built with C#, WinForms, and OpenCV.

The purpose of this project is to develop and validate reusable vision inspection tools commonly used in industrial AOI systems.

Unlike AOI Platform, which focuses on software architecture, PLC communication, and workflow integration, this project focuses on image processing algorithms, inspection tool development, and vision-related research.

The developed tools are planned to be integrated into AOI Platform as the inspection engine in future development.

### Current Features

* ROI Editor
* Sobel Edge Detection
* Threshold Processing
* QR Code Detection
* DataMatrix Detection
* Modular Tool Architecture
* Inspection Result Management

### Future Development

* Blob Analysis
* Pattern Matching
* OCR Inspection
* Geometric Measurement Tools
* AI Defect Detection
* Defect Classification

### Project Goals

* Build a reusable AOI Tool Library
* Practice OpenCV and image processing techniques
* Study industrial AOI inspection methods
* Serve as the inspection engine for AOI Platform


----------
## 系統架構 (System Architecture)

<img width="181" height="829" alt="image" src="https://github.com/user-attachments/assets/4bb62c1d-2fab-45bc-934b-83d2de0f6434" />

----------
## 使用者介面 ( User Interface)

1.主畫面

<img width="762" height="385" alt="image" src="https://github.com/user-attachments/assets/ba82d784-a6fb-440c-93cd-2d0570d122e9" />

2.工具選擇畫面

<img width="620" height="383" alt="image" src="https://github.com/user-attachments/assets/3eaeea17-5fe7-45b7-b10e-0be07d22984e" />

3.工具參數設定畫面

<img width="619" height="382" alt="image" src="https://github.com/user-attachments/assets/45c96189-c001-4d8c-869b-9f28b11713ec" />

4.執行結果+結果輸出

<img width="761" height="385" alt="image" src="https://github.com/user-attachments/assets/ff49904d-b3d6-4c50-82a1-b8e5fbc185e8" />

----------
