using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronObserver
{

	class Program
	{
		//17210622 Pino Alvarez Oscar Brandon
		interface ISubject
		{
			void Attach(IObserver observer);
			void Notificacion();
		}

		class Estadoclima : ISubject
		{
			private List<IObserver> _observers;

			public float Temperatura
			{
				get { return _temperatura; }
				set
				{
					_temperatura = value;
					Notificacion();
				}
			}

			private float _temperatura;
			//17210622 Pino Alvarez Oscar Brandon
			public Estadoclima()
			{
				_observers = new List<IObserver>();
			}

			public void Attach(IObserver observer)
			{
				_observers.Add(observer);
			}

			public void Notificacion()
			{
				_observers.ForEach(o =>
				{
					o.Update(this);
				});
			}
		}

		interface IObserver
		{
			void Update(ISubject subject);
		}

		class Clima : IObserver
		{
			public string Segmentoclima { get; set; }
			//17210622 Pino Alvarez Oscar Brandon
			public Clima(String segmento)
			{
				Segmentoclima = segmento;
			}

			public void Update(ISubject subject)
			{
				if (subject is Estadoclima estadoclima)
				{
					Console.WriteLine(String.Format("{0} temperatura de {1} Fahrenheit",
						Segmentoclima,
						estadoclima.Temperatura));
					Console.WriteLine();
				}
			}
		}

		static void Main(string[] args)
		{
			Estadoclima estadoclima = new Estadoclima();
			Clima clima1 = new Clima("Estado del clima marca una");
			estadoclima.Attach(clima1);
			Clima clima2 = new Clima("Estado nuevo del clima marca una");
			estadoclima.Attach(clima2);
			estadoclima.Temperatura = 17.5f;
			estadoclima.Temperatura = 50.5f;
			estadoclima.Temperatura = 24.5f;
			Console.WriteLine("Pino Alvarez Oscar Brandon");
			Console.ReadLine();
		}
	}
}