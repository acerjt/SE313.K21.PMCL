#include<iostream>
using namespace std;

struct thap
{
	int n;
	char a;
	char b;
	char c;
};

struct stack
{
	thap a[100];
	int t;
};

void CreateStack(stack &s)
{
	s.t = -1;
}
int IsEmpty(stack s)//Stack có rỗng hay không
{
	if (s.t == -1)
		return 1;
	else
		return 0;
}
int IsFull(stack s) //Kiểm tra Stack có đầy hay không
{
	if (s.t >= 100)
		return 1;
	else
		return 0;
}

int Push(stack &s, thap x)
{
	if (IsFull(s) == 0)
	{
		s.t++;
		s.a[s.t] = x;
		return 1;
	}
	else
		return 0;
}

int Pop(stack &s, thap &x)
{
	if (IsEmpty(s) == 0)
	{
		x = s.a[s.t];
		s.t--;
		return 1;
	}
	else
		return 0;
}
void main()
{
	stack s;
	thap Thap;
	char Nguon;
	char TrungGian;
	char Dich;
	int N;
	int m;
	cout << "Nhap so dia: ";
	cin >> m;
	CreateStack(s);
	Thap.n = m; Thap.a = 'A'; Thap.b = 'B'; Thap.c = 'C';
	Push(s, Thap);
	do
	{
		Pop(s, Thap);
		Nguon = Thap.a; TrungGian = Thap.b; Dich = Thap.c;
		if (Thap.n == 1)
			cout << "\nChuyen " << Thap.a << " qua " << Thap.c;
		else
		{
			N = Thap.n;

			Thap.n = N - 1;
			Thap.a = TrungGian;
			Thap.b = Nguon;
			Thap.c = Dich;
			Push(s, Thap);

			Thap.n = 1;
			Thap.a = Nguon;
			Thap.b = TrungGian;
			Thap.c = Dich;
			Push(s, Thap);

			Thap.n = N - 1;
			Thap.a = Nguon;
			Thap.b = Dich;
			Thap.c = TrungGian;
			Push(s, Thap);
		}
	} while (!IsEmpty(s));
	cout << endl;
	system("pause");
}