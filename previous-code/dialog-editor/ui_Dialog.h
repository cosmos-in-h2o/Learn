/********************************************************************************
** Form generated from reading UI file 'DialogYHrSio.ui'
**
** Created by: Qt User Interface Compiler version 5.14.2
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef DIALOGYHRSIO_H
#define DIALOGYHRSIO_H

#include <QtCore/QVariant>
#include <QtWidgets/QAction>
#include <QtWidgets/QApplication>
#include <QtWidgets/QComboBox>
#include <QtWidgets/QDockWidget>
#include <QtWidgets/QHBoxLayout>
#include <QtWidgets/QLabel>
#include <QtWidgets/QLineEdit>
#include <QtWidgets/QMainWindow>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QScrollArea>
#include <QtWidgets/QTextEdit>
#include <QtWidgets/QToolBar>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_DialogClass
{
public:
    QAction *actioncreat_a_program;
    QWidget *centralWidget;
    QDockWidget *dockEditor;
    QWidget *dockEditorW;
    QLabel *block_type;
    QLabel *block_name;
    QLineEdit *nameEdit;
    QComboBox *typeEditor;
    QPushButton *save;
    QScrollArea *scrollArea;
    QWidget *scrollAreaW;
    QTextEdit *textEdit_1;
    QTextEdit *textEdit_2;
    QTextEdit *textEdit_3;
    QTextEdit *textEdit_4;
    QTextEdit *textEdit_5;
    QTextEdit *textEdit_6;
    QTextEdit *textEdit_7;
    QTextEdit *textEdit_8;
    QTextEdit *textEdit_9;
    QTextEdit *textEdit_10;
    QTextEdit *textEdit_11;
    QTextEdit *textEdit_12;
    QTextEdit *textEdit_13;
    QTextEdit *textEdit_14;
    QTextEdit *textEdit_15;
    QTextEdit *textEdit_16;
    QTextEdit *textEdit_17;
    QTextEdit *textEdit_18;
    QTextEdit *textEdit_19;
    QTextEdit *textEdit_20;
    QLineEdit *callBackEdit;
    QLineEdit *boolEdit;
    QPushButton *deleteBtn;
    QDockWidget *dockCode;
    QWidget *dockWidgetContents;
    QHBoxLayout *horizontalLayout;
    QTextEdit *structCode;
    QTextEdit *methodCode;
    QPushButton *exportCodeBtn;
    QDockWidget *dockSet;
    QWidget *dockSetW;
    QPushButton *SaveMain;
    QPushButton *Quit;
    QPushButton *changeBoxSizeBtn;
    QPushButton *CreatBlock;
    QLineEdit *boxSizeY;
    QLineEdit *BlockName;
    QLineEdit *boxSizeX;
    QPushButton *changeBoxPosBtn;
    QLineEdit *boxX;
    QLineEdit *boxY;
    QPushButton *ExportBtn;
    QToolBar *toolBar;

    void setupUi(QMainWindow *DialogClass)
    {
        if (DialogClass->objectName().isEmpty())
            DialogClass->setObjectName(QString::fromUtf8("DialogClass"));
        DialogClass->resize(1215, 915);
        actioncreat_a_program = new QAction(DialogClass);
        actioncreat_a_program->setObjectName(QString::fromUtf8("actioncreat_a_program"));
        centralWidget = new QWidget(DialogClass);
        centralWidget->setObjectName(QString::fromUtf8("centralWidget"));
        centralWidget->setStyleSheet(QString::fromUtf8(""));
        DialogClass->setCentralWidget(centralWidget);
        dockEditor = new QDockWidget(DialogClass);
        dockEditor->setObjectName(QString::fromUtf8("dockEditor"));
        dockEditor->setMinimumSize(QSize(215, 41));
        QFont font;
        font.setFamily(QString::fromUtf8("\345\256\213\344\275\223"));
        font.setPointSize(13);
        dockEditor->setFont(font);
        dockEditor->setStyleSheet(QString::fromUtf8("background-color: rgb(58, 72, 87);\n"
"color: rgb(231, 231, 231);"));
        dockEditorW = new QWidget();
        dockEditorW->setObjectName(QString::fromUtf8("dockEditorW"));
        dockEditorW->setMinimumSize(QSize(200, 0));
        dockEditorW->setStyleSheet(QString::fromUtf8("background-color: rgb(58, 72, 87);\n"
"color: rgb(231, 231, 231);\n"
""));
        block_type = new QLabel(dockEditorW);
        block_type->setObjectName(QString::fromUtf8("block_type"));
        block_type->setGeometry(QRect(9, 35, 54, 16));
        block_name = new QLabel(dockEditorW);
        block_name->setObjectName(QString::fromUtf8("block_name"));
        block_name->setGeometry(QRect(9, 9, 54, 16));
        nameEdit = new QLineEdit(dockEditorW);
        nameEdit->setObjectName(QString::fromUtf8("nameEdit"));
        nameEdit->setGeometry(QRect(69, 9, 121, 20));
        nameEdit->setStyleSheet(QString::fromUtf8("color: rgb(0, 170, 255);\n"
"border : 2px solid#5D6D7E;"));
        typeEditor = new QComboBox(dockEditorW);
        typeEditor->addItem(QString());
        typeEditor->addItem(QString());
        typeEditor->addItem(QString());
        typeEditor->setObjectName(QString::fromUtf8("typeEditor"));
        typeEditor->setGeometry(QRect(69, 35, 121, 16));
        typeEditor->setStyleSheet(QString::fromUtf8("border-style: solid;\n"
""));
        save = new QPushButton(dockEditorW);
        save->setObjectName(QString::fromUtf8("save"));
        save->setGeometry(QRect(10, 110, 181, 22));
        save->setStyleSheet(QString::fromUtf8("/**\346\255\243\345\270\270\346\203\205\345\206\265\344\270\213\346\240\267\345\274\217**/\n"
"QPushButton{\n"
"	font: 9pt \"\345\256\213\344\275\223\";\n"
"    color: rgb(231,231,231);\n"
"    background-color: rgb(50, 65, 79);\n"
"    border-radius: 10px;\n"
"    border-style: solid;\n"
"    border-width: 0px;\n"
"    padding: 5px;\n"
"}\n"
"\n"
"/**\351\274\240\346\240\207\345\201\234\347\225\231\345\234\250\346\214\211\351\222\256\344\270\212\347\232\204\346\240\267\345\274\217**/\n"
"QPushButton::hover{	\n"
"    color: rgb(231,231,231);\n"
"    background-color: rgb(45,60,73);\n"
"}\n"
"\n"
"/**\351\274\240\346\240\207\346\214\211\345\216\213\344\270\213\345\216\273\347\232\204\346\240\267\345\274\217**/\n"
"QPushButton::pressed,QPushButton::checked{\n"
"    color: rgb(231,231,231);\n"
"    background-color: rgb(39,51,61);\n"
"}\n"
""));
        scrollArea = new QScrollArea(dockEditorW);
        scrollArea->setObjectName(QString::fromUtf8("scrollArea"));
        scrollArea->setGeometry(QRect(10, 170, 201, 1000));
        scrollArea->setWidgetResizable(false);
        scrollAreaW = new QWidget();
        scrollAreaW->setObjectName(QString::fromUtf8("scrollAreaW"));
        scrollAreaW->setGeometry(QRect(0, 0, 199, 1998));
        textEdit_1 = new QTextEdit(scrollAreaW);
        textEdit_1->setObjectName(QString::fromUtf8("textEdit_1"));
        textEdit_1->setGeometry(QRect(0, 0, 181, 81));
        QFont font1;
        font1.setFamily(QString::fromUtf8("\345\276\256\350\275\257\351\233\205\351\273\221 Light"));
        font1.setPointSize(10);
        textEdit_1->setFont(font1);
        textEdit_1->setStyleSheet(QString::fromUtf8("color: rgb(0, 170, 255);\n"
"border : 2px solid#5D6D7E;"));
        textEdit_2 = new QTextEdit(scrollAreaW);
        textEdit_2->setObjectName(QString::fromUtf8("textEdit_2"));
        textEdit_2->setGeometry(QRect(0, 80, 181, 81));
        textEdit_2->setFont(font1);
        textEdit_2->setStyleSheet(QString::fromUtf8("color: rgb(0, 170, 255);\n"
"border : 2px solid#5D6D7E;"));
        textEdit_3 = new QTextEdit(scrollAreaW);
        textEdit_3->setObjectName(QString::fromUtf8("textEdit_3"));
        textEdit_3->setGeometry(QRect(0, 160, 181, 81));
        textEdit_3->setFont(font1);
        textEdit_3->setStyleSheet(QString::fromUtf8("color: rgb(0, 170, 255);\n"
"border : 2px solid#5D6D7E;"));
        textEdit_4 = new QTextEdit(scrollAreaW);
        textEdit_4->setObjectName(QString::fromUtf8("textEdit_4"));
        textEdit_4->setGeometry(QRect(0, 240, 181, 81));
        textEdit_4->setFont(font1);
        textEdit_4->setStyleSheet(QString::fromUtf8("color: rgb(0, 170, 255);\n"
"border : 2px solid#5D6D7E;"));
        textEdit_5 = new QTextEdit(scrollAreaW);
        textEdit_5->setObjectName(QString::fromUtf8("textEdit_5"));
        textEdit_5->setGeometry(QRect(0, 320, 181, 81));
        textEdit_5->setFont(font1);
        textEdit_5->setStyleSheet(QString::fromUtf8("color: rgb(0, 170, 255);\n"
"border : 2px solid#5D6D7E;"));
        textEdit_6 = new QTextEdit(scrollAreaW);
        textEdit_6->setObjectName(QString::fromUtf8("textEdit_6"));
        textEdit_6->setGeometry(QRect(0, 400, 181, 81));
        textEdit_6->setFont(font1);
        textEdit_6->setStyleSheet(QString::fromUtf8("color: rgb(0, 170, 255);\n"
"border : 2px solid#5D6D7E;"));
        textEdit_7 = new QTextEdit(scrollAreaW);
        textEdit_7->setObjectName(QString::fromUtf8("textEdit_7"));
        textEdit_7->setGeometry(QRect(0, 480, 181, 81));
        textEdit_7->setFont(font1);
        textEdit_7->setStyleSheet(QString::fromUtf8("color: rgb(0, 170, 255);\n"
"border : 2px solid#5D6D7E;"));
        textEdit_8 = new QTextEdit(scrollAreaW);
        textEdit_8->setObjectName(QString::fromUtf8("textEdit_8"));
        textEdit_8->setGeometry(QRect(0, 560, 181, 81));
        textEdit_8->setFont(font1);
        textEdit_8->setStyleSheet(QString::fromUtf8("color: rgb(0, 170, 255);\n"
"border : 2px solid#5D6D7E;"));
        textEdit_9 = new QTextEdit(scrollAreaW);
        textEdit_9->setObjectName(QString::fromUtf8("textEdit_9"));
        textEdit_9->setGeometry(QRect(0, 640, 181, 81));
        textEdit_9->setFont(font1);
        textEdit_9->setStyleSheet(QString::fromUtf8("color: rgb(0, 170, 255);\n"
"border : 2px solid#5D6D7E;"));
        textEdit_10 = new QTextEdit(scrollAreaW);
        textEdit_10->setObjectName(QString::fromUtf8("textEdit_10"));
        textEdit_10->setGeometry(QRect(0, 720, 181, 81));
        textEdit_10->setFont(font1);
        textEdit_10->setStyleSheet(QString::fromUtf8("color: rgb(0, 170, 255);\n"
"border : 2px solid#5D6D7E;"));
        textEdit_11 = new QTextEdit(scrollAreaW);
        textEdit_11->setObjectName(QString::fromUtf8("textEdit_11"));
        textEdit_11->setGeometry(QRect(0, 800, 181, 81));
        textEdit_11->setFont(font1);
        textEdit_11->setStyleSheet(QString::fromUtf8("color: rgb(0, 170, 255);\n"
"border : 2px solid#5D6D7E;"));
        textEdit_12 = new QTextEdit(scrollAreaW);
        textEdit_12->setObjectName(QString::fromUtf8("textEdit_12"));
        textEdit_12->setGeometry(QRect(0, 880, 181, 81));
        textEdit_12->setFont(font1);
        textEdit_12->setStyleSheet(QString::fromUtf8("color: rgb(0, 170, 255);\n"
"border : 2px solid#5D6D7E;"));
        textEdit_13 = new QTextEdit(scrollAreaW);
        textEdit_13->setObjectName(QString::fromUtf8("textEdit_13"));
        textEdit_13->setGeometry(QRect(0, 960, 181, 81));
        textEdit_13->setFont(font1);
        textEdit_13->setStyleSheet(QString::fromUtf8("color: rgb(0, 170, 255);\n"
"border : 2px solid#5D6D7E;"));
        textEdit_14 = new QTextEdit(scrollAreaW);
        textEdit_14->setObjectName(QString::fromUtf8("textEdit_14"));
        textEdit_14->setGeometry(QRect(0, 1040, 181, 81));
        textEdit_14->setFont(font1);
        textEdit_14->setStyleSheet(QString::fromUtf8("color: rgb(0, 170, 255);\n"
"border : 2px solid#5D6D7E;"));
        textEdit_15 = new QTextEdit(scrollAreaW);
        textEdit_15->setObjectName(QString::fromUtf8("textEdit_15"));
        textEdit_15->setGeometry(QRect(0, 1120, 181, 81));
        textEdit_15->setFont(font1);
        textEdit_15->setStyleSheet(QString::fromUtf8("color: rgb(0, 170, 255);\n"
"border : 2px solid#5D6D7E;"));
        textEdit_16 = new QTextEdit(scrollAreaW);
        textEdit_16->setObjectName(QString::fromUtf8("textEdit_16"));
        textEdit_16->setGeometry(QRect(0, 1200, 181, 81));
        textEdit_16->setFont(font1);
        textEdit_16->setStyleSheet(QString::fromUtf8("color: rgb(0, 170, 255);\n"
"border : 2px solid#5D6D7E;"));
        textEdit_17 = new QTextEdit(scrollAreaW);
        textEdit_17->setObjectName(QString::fromUtf8("textEdit_17"));
        textEdit_17->setGeometry(QRect(0, 1280, 181, 81));
        textEdit_17->setFont(font1);
        textEdit_17->setStyleSheet(QString::fromUtf8("color: rgb(0, 170, 255);\n"
"border : 2px solid#5D6D7E;"));
        textEdit_18 = new QTextEdit(scrollAreaW);
        textEdit_18->setObjectName(QString::fromUtf8("textEdit_18"));
        textEdit_18->setGeometry(QRect(0, 1360, 181, 81));
        textEdit_18->setFont(font1);
        textEdit_18->setStyleSheet(QString::fromUtf8("color: rgb(0, 170, 255);\n"
"border : 2px solid#5D6D7E;"));
        textEdit_19 = new QTextEdit(scrollAreaW);
        textEdit_19->setObjectName(QString::fromUtf8("textEdit_19"));
        textEdit_19->setGeometry(QRect(0, 1440, 181, 81));
        textEdit_19->setFont(font1);
        textEdit_19->setStyleSheet(QString::fromUtf8("color: rgb(0, 170, 255);\n"
"border : 2px solid#5D6D7E;"));
        textEdit_20 = new QTextEdit(scrollAreaW);
        textEdit_20->setObjectName(QString::fromUtf8("textEdit_20"));
        textEdit_20->setGeometry(QRect(0, 1520, 181, 81));
        textEdit_20->setFont(font1);
        textEdit_20->setStyleSheet(QString::fromUtf8("color: rgb(0, 170, 255);\n"
"border : 2px solid#5D6D7E;"));
        scrollArea->setWidget(scrollAreaW);
        callBackEdit = new QLineEdit(dockEditorW);
        callBackEdit->setObjectName(QString::fromUtf8("callBackEdit"));
        callBackEdit->setGeometry(QRect(10, 85, 181, 20));
        callBackEdit->setStyleSheet(QString::fromUtf8("color: rgb(0, 170, 255);\n"
"border : 2px solid#5D6D7E;"));
        boolEdit = new QLineEdit(dockEditorW);
        boolEdit->setObjectName(QString::fromUtf8("boolEdit"));
        boolEdit->setGeometry(QRect(10, 60, 181, 20));
        boolEdit->setStyleSheet(QString::fromUtf8("color: rgb(0, 170, 255);\n"
"border : 2px solid#5D6D7E;"));
        deleteBtn = new QPushButton(dockEditorW);
        deleteBtn->setObjectName(QString::fromUtf8("deleteBtn"));
        deleteBtn->setGeometry(QRect(10, 140, 181, 22));
        deleteBtn->setStyleSheet(QString::fromUtf8("/**\346\255\243\345\270\270\346\203\205\345\206\265\344\270\213\346\240\267\345\274\217**/\n"
"QPushButton{\n"
"	font: 9pt \"\345\256\213\344\275\223\";\n"
"    color: rgb(231,231,231);\n"
"    background-color: rgb(50, 65, 79);\n"
"    border-radius: 10px;\n"
"    border-style: solid;\n"
"    border-width: 0px;\n"
"    padding: 5px;\n"
"}\n"
"\n"
"/**\351\274\240\346\240\207\345\201\234\347\225\231\345\234\250\346\214\211\351\222\256\344\270\212\347\232\204\346\240\267\345\274\217**/\n"
"QPushButton::hover{	\n"
"    color: rgb(231,231,231);\n"
"    background-color: rgb(45,60,73);\n"
"}\n"
"\n"
"/**\351\274\240\346\240\207\346\214\211\345\216\213\344\270\213\345\216\273\347\232\204\346\240\267\345\274\217**/\n"
"QPushButton::pressed,QPushButton::checked{\n"
"    color: rgb(231,231,231);\n"
"    background-color: rgb(39,51,61);\n"
"}\n"
""));
        dockEditor->setWidget(dockEditorW);
        DialogClass->addDockWidget(Qt::RightDockWidgetArea, dockEditor);
        dockCode = new QDockWidget(DialogClass);
        dockCode->setObjectName(QString::fromUtf8("dockCode"));
        dockCode->setMinimumSize(QSize(235, 114));
        dockCode->setFont(font);
        dockCode->setStyleSheet(QString::fromUtf8("background-color: rgb(58, 72, 87);\n"
"color: rgb(231, 231, 231);"));
        dockWidgetContents = new QWidget();
        dockWidgetContents->setObjectName(QString::fromUtf8("dockWidgetContents"));
        horizontalLayout = new QHBoxLayout(dockWidgetContents);
        horizontalLayout->setSpacing(6);
        horizontalLayout->setContentsMargins(11, 11, 11, 11);
        horizontalLayout->setObjectName(QString::fromUtf8("horizontalLayout"));
        structCode = new QTextEdit(dockWidgetContents);
        structCode->setObjectName(QString::fromUtf8("structCode"));
        QFont font2;
        font2.setFamily(QString::fromUtf8("Consolas"));
        font2.setPointSize(15);
        font2.setStyleStrategy(QFont::PreferAntialias);
        structCode->setFont(font2);
        structCode->setStyleSheet(QString::fromUtf8("color: #df5a65;\n"
"background-color:#566573;"));

        horizontalLayout->addWidget(structCode);

        methodCode = new QTextEdit(dockWidgetContents);
        methodCode->setObjectName(QString::fromUtf8("methodCode"));
        methodCode->setFont(font2);
        methodCode->setStyleSheet(QString::fromUtf8("color: #df5a65;\n"
"background-color:#566573;"));

        horizontalLayout->addWidget(methodCode);

        exportCodeBtn = new QPushButton(dockWidgetContents);
        exportCodeBtn->setObjectName(QString::fromUtf8("exportCodeBtn"));
        exportCodeBtn->setStyleSheet(QString::fromUtf8("/**\346\255\243\345\270\270\346\203\205\345\206\265\344\270\213\346\240\267\345\274\217**/\n"
"QPushButton{\n"
"	font: 9pt \"\345\256\213\344\275\223\";\n"
"    color: rgb(231,231,231);\n"
"    background-color: rgb(50, 65, 79);\n"
"    border-radius: 10px;\n"
"    border-style: solid;\n"
"    border-width: 0px;\n"
"    padding: 5px;\n"
"}\n"
"\n"
"/**\351\274\240\346\240\207\345\201\234\347\225\231\345\234\250\346\214\211\351\222\256\344\270\212\347\232\204\346\240\267\345\274\217**/\n"
"QPushButton::hover{	\n"
"    color: rgb(231,231,231);\n"
"    background-color: rgb(45,60,73);\n"
"}\n"
"\n"
"/**\351\274\240\346\240\207\346\214\211\345\216\213\344\270\213\345\216\273\347\232\204\346\240\267\345\274\217**/\n"
"QPushButton::pressed,QPushButton::checked{\n"
"    color: rgb(231,231,231);\n"
"    background-color: rgb(39,51,61);\n"
"}"));

        horizontalLayout->addWidget(exportCodeBtn);

        dockCode->setWidget(dockWidgetContents);
        DialogClass->addDockWidget(Qt::TopDockWidgetArea, dockCode);
        dockSet = new QDockWidget(DialogClass);
        dockSet->setObjectName(QString::fromUtf8("dockSet"));
        dockSet->setFont(font);
        dockSet->setStyleSheet(QString::fromUtf8("background-color: rgb(58, 72, 87);\n"
"color: rgb(231, 231, 231);"));
        dockSetW = new QWidget();
        dockSetW->setObjectName(QString::fromUtf8("dockSetW"));
        SaveMain = new QPushButton(dockSetW);
        SaveMain->setObjectName(QString::fromUtf8("SaveMain"));
        SaveMain->setGeometry(QRect(90, 10, 75, 25));
        QFont font3;
        font3.setFamily(QString::fromUtf8("\345\256\213\344\275\223"));
        font3.setPointSize(9);
        font3.setBold(false);
        font3.setItalic(false);
        font3.setWeight(50);
        SaveMain->setFont(font3);
        SaveMain->setStyleSheet(QString::fromUtf8("/**\346\255\243\345\270\270\346\203\205\345\206\265\344\270\213\346\240\267\345\274\217**/\n"
"QPushButton{\n"
"	font: 9pt \"\345\256\213\344\275\223\";\n"
"    color: rgb(231,231,231);\n"
"    background-color: rgb(50, 65, 79);\n"
"    border-radius: 10px;\n"
"    border-style: solid;\n"
"    border-width: 0px;\n"
"    padding: 5px;\n"
"}\n"
"\n"
"/**\351\274\240\346\240\207\345\201\234\347\225\231\345\234\250\346\214\211\351\222\256\344\270\212\347\232\204\346\240\267\345\274\217**/\n"
"QPushButton::hover{	\n"
"    color: rgb(231,231,231);\n"
"    background-color: rgb(45,60,73);\n"
"}\n"
"\n"
"/**\351\274\240\346\240\207\346\214\211\345\216\213\344\270\213\345\216\273\347\232\204\346\240\267\345\274\217**/\n"
"QPushButton::pressed,QPushButton::checked{\n"
"    color: rgb(231,231,231);\n"
"    background-color: rgb(39,51,61);\n"
"}\n"
""));
        Quit = new QPushButton(dockSetW);
        Quit->setObjectName(QString::fromUtf8("Quit"));
        Quit->setGeometry(QRect(10, 10, 75, 25));
        Quit->setFont(font3);
        Quit->setStyleSheet(QString::fromUtf8("/**\346\255\243\345\270\270\346\203\205\345\206\265\344\270\213\346\240\267\345\274\217**/\n"
"QPushButton{\n"
"	font: 9pt \"\345\256\213\344\275\223\";\n"
"    color: rgb(231,231,231);\n"
"    background-color: rgb(50, 65, 79);\n"
"    border-radius: 10px;\n"
"    border-style: solid;\n"
"    border-width: 0px;\n"
"    padding: 5px;\n"
"}\n"
"\n"
"/**\351\274\240\346\240\207\345\201\234\347\225\231\345\234\250\346\214\211\351\222\256\344\270\212\347\232\204\346\240\267\345\274\217**/\n"
"QPushButton::hover{	\n"
"    color: rgb(231,231,231);\n"
"    background-color: rgb(45,60,73);\n"
"}\n"
"\n"
"/**\351\274\240\346\240\207\346\214\211\345\216\213\344\270\213\345\216\273\347\232\204\346\240\267\345\274\217**/\n"
"QPushButton::pressed,QPushButton::checked{\n"
"    color: rgb(231,231,231);\n"
"    background-color: rgb(39,51,61);\n"
"}\n"
""));
        changeBoxSizeBtn = new QPushButton(dockSetW);
        changeBoxSizeBtn->setObjectName(QString::fromUtf8("changeBoxSizeBtn"));
        changeBoxSizeBtn->setGeometry(QRect(10, 70, 75, 25));
        changeBoxSizeBtn->setFont(font3);
        changeBoxSizeBtn->setStyleSheet(QString::fromUtf8("/**\346\255\243\345\270\270\346\203\205\345\206\265\344\270\213\346\240\267\345\274\217**/\n"
"QPushButton{\n"
"	font: 9pt \"\345\256\213\344\275\223\";\n"
"    color: rgb(231,231,231);\n"
"    background-color: rgb(50, 65, 79);\n"
"    border-radius: 10px;\n"
"    border-style: solid;\n"
"    border-width: 0px;\n"
"    padding: 5px;\n"
"}\n"
"\n"
"/**\351\274\240\346\240\207\345\201\234\347\225\231\345\234\250\346\214\211\351\222\256\344\270\212\347\232\204\346\240\267\345\274\217**/\n"
"QPushButton::hover{	\n"
"    color: rgb(231,231,231);\n"
"    background-color: rgb(45,60,73);\n"
"}\n"
"\n"
"/**\351\274\240\346\240\207\346\214\211\345\216\213\344\270\213\345\216\273\347\232\204\346\240\267\345\274\217**/\n"
"QPushButton::pressed,QPushButton::checked{\n"
"    color: rgb(231,231,231);\n"
"    background-color: rgb(39,51,61);\n"
"}\n"
""));
        CreatBlock = new QPushButton(dockSetW);
        CreatBlock->setObjectName(QString::fromUtf8("CreatBlock"));
        CreatBlock->setGeometry(QRect(10, 40, 75, 25));
        CreatBlock->setFont(font3);
        CreatBlock->setStyleSheet(QString::fromUtf8("/**\346\255\243\345\270\270\346\203\205\345\206\265\344\270\213\346\240\267\345\274\217**/\n"
"QPushButton{\n"
"	font: 9pt \"\345\256\213\344\275\223\";\n"
"    color: rgb(231,231,231);\n"
"    background-color: rgb(50, 65, 79);\n"
"    border-radius: 10px;\n"
"    border-style: solid;\n"
"    border-width: 0px;\n"
"    padding: 5px;\n"
"}\n"
"\n"
"/**\351\274\240\346\240\207\345\201\234\347\225\231\345\234\250\346\214\211\351\222\256\344\270\212\347\232\204\346\240\267\345\274\217**/\n"
"QPushButton::hover{	\n"
"    color: rgb(231,231,231);\n"
"    background-color: rgb(45,60,73);\n"
"}\n"
"\n"
"/**\351\274\240\346\240\207\346\214\211\345\216\213\344\270\213\345\216\273\347\232\204\346\240\267\345\274\217**/\n"
"QPushButton::pressed,QPushButton::checked{\n"
"    color: rgb(231,231,231);\n"
"    background-color: rgb(39,51,61);\n"
"}\n"
""));
        boxSizeY = new QLineEdit(dockSetW);
        boxSizeY->setObjectName(QString::fromUtf8("boxSizeY"));
        boxSizeY->setGeometry(QRect(170, 70, 75, 25));
        boxSizeY->setStyleSheet(QString::fromUtf8("background-color:rgb(58, 72, 87);\n"
"color:rgb(231, 231, 231);\n"
"border : 2px solid#5D6D7E;"));
        BlockName = new QLineEdit(dockSetW);
        BlockName->setObjectName(QString::fromUtf8("BlockName"));
        BlockName->setGeometry(QRect(90, 40, 120, 25));
        BlockName->setStyleSheet(QString::fromUtf8("background-color: rgb(58, 72, 87);\n"
"color: rgb(231, 231, 231);\n"
"border : 2px solid#5D6D7E;"));
        boxSizeX = new QLineEdit(dockSetW);
        boxSizeX->setObjectName(QString::fromUtf8("boxSizeX"));
        boxSizeX->setGeometry(QRect(90, 70, 75, 25));
        boxSizeX->setStyleSheet(QString::fromUtf8("background-color:rgb(58, 72, 87);\n"
"color:rgb(231, 231, 231);\n"
"\n"
"border : 2px solid#5D6D7E;"));
        changeBoxPosBtn = new QPushButton(dockSetW);
        changeBoxPosBtn->setObjectName(QString::fromUtf8("changeBoxPosBtn"));
        changeBoxPosBtn->setGeometry(QRect(10, 100, 75, 25));
        changeBoxPosBtn->setFont(font3);
        changeBoxPosBtn->setStyleSheet(QString::fromUtf8("/**\346\255\243\345\270\270\346\203\205\345\206\265\344\270\213\346\240\267\345\274\217**/\n"
"QPushButton{\n"
"	font: 9pt \"\345\256\213\344\275\223\";\n"
"    color: rgb(231,231,231);\n"
"    background-color: rgb(50, 65, 79);\n"
"    border-radius: 10px;\n"
"    border-style: solid;\n"
"    border-width: 0px;\n"
"    padding: 5px;\n"
"}\n"
"\n"
"/**\351\274\240\346\240\207\345\201\234\347\225\231\345\234\250\346\214\211\351\222\256\344\270\212\347\232\204\346\240\267\345\274\217**/\n"
"QPushButton::hover{	\n"
"    color: rgb(231,231,231);\n"
"    background-color: rgb(45,60,73);\n"
"}\n"
"\n"
"/**\351\274\240\346\240\207\346\214\211\345\216\213\344\270\213\345\216\273\347\232\204\346\240\267\345\274\217**/\n"
"QPushButton::pressed,QPushButton::checked{\n"
"    color: rgb(231,231,231);\n"
"    background-color: rgb(39,51,61);\n"
"}\n"
""));
        boxX = new QLineEdit(dockSetW);
        boxX->setObjectName(QString::fromUtf8("boxX"));
        boxX->setGeometry(QRect(90, 100, 75, 25));
        boxX->setStyleSheet(QString::fromUtf8("background-color:rgb(58, 72, 87);\n"
"color:rgb(231, 231, 231);\n"
"border : 2px solid#5D6D7E;"));
        boxY = new QLineEdit(dockSetW);
        boxY->setObjectName(QString::fromUtf8("boxY"));
        boxY->setGeometry(QRect(170, 100, 75, 25));
        boxY->setStyleSheet(QString::fromUtf8("background-color:rgb(58, 72, 87);\n"
"color:rgb(231, 231, 231);\n"
"border : 2px solid#5D6D7E;"));
        ExportBtn = new QPushButton(dockSetW);
        ExportBtn->setObjectName(QString::fromUtf8("ExportBtn"));
        ExportBtn->setGeometry(QRect(170, 10, 75, 25));
        ExportBtn->setFont(font3);
        ExportBtn->setStyleSheet(QString::fromUtf8("/**\346\255\243\345\270\270\346\203\205\345\206\265\344\270\213\346\240\267\345\274\217**/\n"
"QPushButton{\n"
"	font: 9pt \"\345\256\213\344\275\223\";\n"
"    color: rgb(231,231,231);\n"
"    background-color: rgb(50, 65, 79);\n"
"    border-radius: 10px;\n"
"    border-style: solid;\n"
"    border-width: 0px;\n"
"    padding: 5px;\n"
"}\n"
"\n"
"/**\351\274\240\346\240\207\345\201\234\347\225\231\345\234\250\346\214\211\351\222\256\344\270\212\347\232\204\346\240\267\345\274\217**/\n"
"QPushButton::hover{	\n"
"    color: rgb(231,231,231);\n"
"    background-color: rgb(45,60,73);\n"
"}\n"
"\n"
"/**\351\274\240\346\240\207\346\214\211\345\216\213\344\270\213\345\216\273\347\232\204\346\240\267\345\274\217**/\n"
"QPushButton::pressed,QPushButton::checked{\n"
"    color: rgb(231,231,231);\n"
"    background-color: rgb(39,51,61);\n"
"}\n"
""));
        dockSet->setWidget(dockSetW);
        DialogClass->addDockWidget(Qt::LeftDockWidgetArea, dockSet);
        toolBar = new QToolBar(DialogClass);
        toolBar->setObjectName(QString::fromUtf8("toolBar"));
        QFont font4;
        font4.setFamily(QString::fromUtf8("\345\256\213\344\275\223"));
        font4.setPointSize(12);
        toolBar->setFont(font4);
        toolBar->setStyleSheet(QString::fromUtf8("background-color: rgb(58, 72, 87);\n"
"color: rgb(231, 231, 231);"));
        DialogClass->addToolBar(Qt::TopToolBarArea, toolBar);

        retranslateUi(DialogClass);

        QMetaObject::connectSlotsByName(DialogClass);
    } // setupUi

    void retranslateUi(QMainWindow *DialogClass)
    {
        DialogClass->setWindowTitle(QCoreApplication::translate("DialogClass", "Dialog", nullptr));
        actioncreat_a_program->setText(QCoreApplication::translate("DialogClass", "creat a program", nullptr));
        dockEditor->setWindowTitle(QCoreApplication::translate("DialogClass", "Block\347\274\226\350\276\221\345\231\250", nullptr));
        block_type->setText(QCoreApplication::translate("DialogClass", "Block\347\261\273\345\236\213", nullptr));
        block_name->setText(QCoreApplication::translate("DialogClass", "Block\345\220\215\345\255\227", nullptr));
        typeEditor->setItemText(0, QCoreApplication::translate("DialogClass", "Dialog", nullptr));
        typeEditor->setItemText(1, QCoreApplication::translate("DialogClass", "Menu", nullptr));
        typeEditor->setItemText(2, QCoreApplication::translate("DialogClass", "MenuWithTime", nullptr));

        save->setText(QCoreApplication::translate("DialogClass", "save", nullptr));
        deleteBtn->setText(QCoreApplication::translate("DialogClass", "delete", nullptr));
        exportCodeBtn->setText(QCoreApplication::translate("DialogClass", "\345\257\274\345\207\272", nullptr));
        SaveMain->setText(QCoreApplication::translate("DialogClass", "\344\277\235\345\255\230", nullptr));
        Quit->setText(QCoreApplication::translate("DialogClass", "\351\200\200\345\207\272", nullptr));
        changeBoxSizeBtn->setText(QCoreApplication::translate("DialogClass", "Box\345\244\247\345\260\217", nullptr));
        CreatBlock->setText(QCoreApplication::translate("DialogClass", "\346\226\260\345\273\272block", nullptr));
        changeBoxPosBtn->setText(QCoreApplication::translate("DialogClass", "\345\201\217\347\247\273\345\235\220\346\240\207", nullptr));
        ExportBtn->setText(QCoreApplication::translate("DialogClass", "\345\257\274\345\207\272", nullptr));
        toolBar->setWindowTitle(QCoreApplication::translate("DialogClass", "toolBar", nullptr));
    } // retranslateUi

};

namespace Ui {
    class DialogClass: public Ui_DialogClass {};
} // namespace Ui

QT_END_NAMESPACE

#endif // DIALOGYHRSIO_H
