using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_044
{
    class Node
    {
        public int no_induk;
        public string nama;
        public string kls;
        public Node next;
        public Node prev;
    }
    class DoubleLink
    {
        Node awal;

        public DoubleLink()
        {
            awal = null;
        }
        public void tambah()
        {
            int nim;
            string nm;
            string kelas;
            Console.Write("Masukan Nomor Induk: ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukan Nama: ");
            nm = Console.ReadLine();
            Console.Write("Masukan Kelas: ");
            kelas = Convert.ToString(Console.ReadLine());
            Node newNode = new Node();
            newNode.no_induk = nim;
            newNode.nama = nm;
            newNode.kls = kelas;

            if (awal == null || nim == awal.no_induk)
            {
                if ((awal != null) && (nim == awal.no_induk))
                {
                    Console.WriteLine("Tidak Boleh duplikat");
                    return;
                }
                newNode.next = awal;
                if (awal != null)
                    awal.prev = newNode;
                newNode.prev = null;
                awal = newNode;
                return;
            }
            Node previous, current;
            for(current = previous = awal;
                current != null && nim >= current.no_induk;
                previous = current, current = current.next)
            {
                if(nim == current.no_induk)
                {
                    Console.WriteLine("Tidak Boleh Duplikat");
                    return;
                }
            }
            newNode.next = current;
            newNode.prev = previous;

            if(current == null)
            {
                newNode.next = current;
                previous.next = newNode;
                return;
            }
            current.prev = newNode;
            previous.next = newNode;
        }
        public bool search(string rollkel, ref Node previous, ref Node current)
        {
            previous = awal;
            current = awal;
            while ((current != null) && (rollkel != current.kls))
            {
                previous = current;
                current = current.next;
            }
            if (current == null)
                return false;
            else
                return true;
        }
        public bool listEmpty()
        {
            if (awal == null)
                return true;
            else
                return false;
        }
        public void display()
        {
            if (listEmpty())
                Console.WriteLine("\nList is Empty");
            else
            {
                Console.WriteLine("Data berdasarkan kelas:\n");
                Node currentNode;
                for (currentNode = awal; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.no_induk + "" + currentNode.nama + "" + currentNode.kls+ "\n");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DoubleLink dl = new DoubleLink();
            while (true)
            {
                try
                {
                    Console.WriteLine("1. Tambah Data");
                    Console.WriteLine("2. Cari Data");
                    Console.WriteLine("3. Tampilkan Data");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                dl.tambah();
                            }break;
                        case '2':
                            {
                                if (dl.listEmpty() == true)
                                {
                                    Console.WriteLine("Kosong");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.WriteLine("Masukan Kelas: ");
                                string klas = Convert.ToString(Console.ReadLine());
                                if (dl.search(klas, ref prev, ref curr) == false)
                                    Console.WriteLine("Data tidak ada");
                                else
                                {
                                    Console.WriteLine("Nomor Induk: " + curr.no_induk);
                                    Console.WriteLine("Nama: " + curr.nama);
                                    Console.WriteLine("Kelas: " + curr.kls);
                                }
                            }break;
                        case '3':
                            {
                                dl.display();
                            }break;
                    }
                }catch(Exception e)
                {
                    Console.WriteLine("Mohon lihat ulang");
                }
            }
        }
    }
}
// 2. Saya menggunakan algoritma double Linked List. Terdapat algoritma untuk mencari data, menampilkan, dan menambahkan data
// 3. TOP pada algoritma stack adalah bagian teratas dari suatu array pada algoritma stack
// 4. Insert dan Delete
// 5. a) Terdapat 4 kedalaman. b) Data tersebut dapat dibaca dengan urutan prioritas data pada sebelah kiri dari induk terlebih dahulu,
//                                lalu dilanjut dengan data sebelah kanan dari induk, lalu data dari induk itu sendiri