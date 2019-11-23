#!/usr/bin/python
# -*- coding: UTF-8 -*-

import getopt
import sys
import re
import os
import random
import codecs
reload(sys)
sys.setdefaultencoding('utf-8')

view_tpl_file = 'view.cs.txt'
control_tpl_file = 'controller.cs.txt'
model_tpl_file = 'model.cs.txt'


def create_dir(dir_name):
    if os.path.exists(dir_name) == False:
        os.mkdir(dir_name)


def save_file(path, data):
    file = codecs.open(path, 'w', 'utf-8')
    if file:
        file.write(data.decode('utf-8'))
        file.close()


def get_file_content(path):
    file = open(path, 'r')
    if file:
        return file.read()
    return ''


def usage():
    print 'Usage:code_gen.py --class=xxx --name=yyy'


def gen_view(class_name):
    name_list = []
    for li in class_name.split('_'):
        name_list.append(li.capitalize())
    class_name = ''.join(name_list)
    file_name = class_name + 'Window'
    content = get_file_content(view_tpl_file)
    save_file('../Assets/Script/GameView/'+file_name+'.cs', content % {'class_name': class_name.capitalize()})
    print "gen " + file_name + " success!"

def gen_control(class_name):
    name_list = []
    for li in class_name.split('_'):
        name_list.append(li.capitalize())
    class_name = ''.join(name_list)
    file_name = class_name + 'Control'
    content = get_file_content(control_tpl_file)
    save_file('../Assets/Script/GameControl/'+file_name+'.cs', content % {'class_name': class_name.capitalize()})
    print "gen " + file_name + " success!"

def gen_model(class_name):
    name_list = []
    for li in class_name.split('_'):
        name_list.append(li.capitalize())
    class_name = ''.join(name_list)
    file_name = class_name + 'Model'
    content = get_file_content(model_tpl_file)
    save_file('../Assets/Script/GameModel/'+file_name+'.cs', content % {'class_name': class_name.capitalize()})
    print "gen " + file_name + " success!"


if __name__ == '__main__':
    opts, args = getopt.getopt(sys.argv[1:], 'h', ['help', 'class=', 'name='])
    class_name = ''
    instance_name = ''
    for op, value in opts:
        if op == "--class":
            class_name = value
        elif op == "--name":
            instance_name = value
        elif op in ("-h", "--help"):
            usage()
            sys.exit()

    if class_name == 'view':
        gen_view(instance_name)
    elif class_name == 'control':
        gen_control(instance_name)
    elif class_name == 'model':
        gen_model(instance_name)
    else:
        print "invalid class name!"
