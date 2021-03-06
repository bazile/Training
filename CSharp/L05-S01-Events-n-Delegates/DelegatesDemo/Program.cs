﻿using System;

namespace TrainingCenter.DelegatesDemo
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] emails = GetEmails();

			// Сортируем массив.
			// Используем полный синтаксис для работы с делегатом - new Xyz(Foo)
			Array.Sort(emails, new Comparison<string>(SortByDomain));

			#region Cокращенный синтаксис
			
			//// Начиная с C# 2.0 можно использовать сокращенный синтаксис
			//// Достаточно передать имя функции. Компилятор создаст экземпляр делегата самостоятельно
			//Array.Sort(emails, SortByDomain);

			#endregion

			#region Анонимный делегат

			//// Если функция нужна только в одном месте, то использование
			////	анонимного делегата может улучшить читабельность кода
			//Array.Sort(
			//    emails,
			//    delegate(string email1, string email2)
			//    {
			//        string domain1 = email1.Substring(email1.IndexOf('@') + 1);
			//        string domain2 = email2.Substring(email2.IndexOf('@') + 1);
			//        int result = string.Compare(domain1, domain2, StringComparison.OrdinalIgnoreCase);
			//        return result == 0 ? string.Compare(email1, email2, StringComparison.OrdinalIgnoreCase) : result;
			//    }
			//);

			#endregion

			#region λ-выражения (лямбда)

			//Array.Sort(
			//    emails,
			//    (string email1, string email2)
			//    => // Это лямбда-оператор. Он отделяет список аргументов функции от её тела
			//    {
			//        string domain1 = email1.Substring(email1.IndexOf('@') + 1);
			//        string domain2 = email2.Substring(email2.IndexOf('@') + 1);
			//        int result = string.Compare(domain1, domain2, StringComparison.OrdinalIgnoreCase);
			//        return result == 0 ? string.Compare(email1, email2, StringComparison.OrdinalIgnoreCase) : result;
			//    }
			//);
			
			#region Типы аргументов можно опустить

			Array.Sort(
				emails,
				(email1, email2) // Мы убрали типы а аргументов т.к. компилятор может их "угадать"
				=> // Это лямбда-оператор. Он отделяет список аргументов функции от её тела
				{
					string domain1 = email1.Substring(email1.IndexOf('@') + 1);
					string domain2 = email2.Substring(email2.IndexOf('@') + 1);
					int result = string.Compare(domain1, domain2, StringComparison.OrdinalIgnoreCase);
					return result == 0 ? string.Compare(email1, email2, StringComparison.OrdinalIgnoreCase) : result;
				}
			);

			#endregion

			#region λ-выражения для функций с одной return строкой

			//Array.Sort(
			//    emails,
			//    (email1, email2)
			//    =>
			//    {
			//        return string.Compare(GetDomain(email1), GetDomain(email2), StringComparison.OrdinalIgnoreCase);
			//    }
			//);

			//Array.Sort(
			//    emails,
			//    (email1, email2) => string.Compare(GetDomain(email1), GetDomain(email2), StringComparison.OrdinalIgnoreCase)
			//);

			#endregion

			#endregion

			foreach (string email in emails)
			{
				Console.WriteLine(email);
			}
		}

		private static int SortByDomain(string email1, string email2)
		{
			string domain1 = email1.Substring(email1.IndexOf('@') + 1);
			string domain2 = email2.Substring(email2.IndexOf('@') + 1);
			// Сравниваем домены
			int result = string.Compare(domain1, domain2, StringComparison.OrdinalIgnoreCase);
			// Если домены совпадают, то сортируем по полному адресу
			return result == 0 ? string.Compare(email1, email2, StringComparison.OrdinalIgnoreCase) : result;
		}

		private static string GetDomain(string email)
		{
			return email.Substring(email.IndexOf('@') + 1);
		}

		#region GetEmails
		private static string[] GetEmails()
		{
			return new string[]
				{
					"jyoung0@blog.com",
					"cfisher1@hhs.gov",
					"gpierce2@theatlantic.com",
					"hcampbell3@mtv.com",
					"jfuller4@admin.ch",
					"bmurphy5@nydailynews.com",
					"abaker6@addthis.com",
					"efernandez7@google.es",
					"arobinson8@theguardian.com",
					"lperkins9@rambler.ru",
					"dburnsa@abc.net.au",
					"afranklinb@npr.org",
					"lknightc@php.net",
					"nandersond@yolasite.com",
					"btorrese@woothemes.com",
					"jpaynef@alexa.com",
					"greedg@cyberchimps.com",
					"ccarrh@sciencedirect.com",
					"jryani@yandex.ru",
					"lpalmerj@mac.com",
					"gvasquezk@mapy.cz",
					"cwashingtonl@marriott.com",
					"hpattersonm@privacy.gov.au",
					"dgarcian@flickr.com",
					"galexandero@salon.com",
					"dcoxp@harvard.edu",
					"vrossq@seattletimes.com",
					"sfreemanr@japanpost.jp",
					"ahills@sciencedirect.com",
					"kfieldst@tumblr.com",
					"bwashingtonu@cisco.com",
					"dcookv@wiley.com",
					"twoodw@army.mil",
					"dwilliamsonx@bloomberg.com",
					"ncolemany@shareasale.com",
					"fstephensz@hatena.ne.jp",
					"ppatterson10@sphinn.com",
					"hbell11@zimbio.com",
					"abowman12@dedecms.com",
					"choward13@fda.gov",
					"rlawson14@digg.com",
					"cjames15@chron.com",
					"mrichards16@ezinearticles.com",
					"dmccoy17@meetup.com",
					"jlane18@google.com.hk",
					"sdunn19@independent.co.uk",
					"mramirez1a@nydailynews.com",
					"dlane1b@techcrunch.com",
					"nburns1c@bloomberg.com",
					"amyers1d@webnode.com",
					"dgonzalez1e@mysql.com",
					"pburke1f@senate.gov",
					"bjones1g@topsy.com",
					"rlane1h@tiny.cc",
					"acarter1i@msu.edu",
					"bmiller1j@wikipedia.org",
					"jcollins1k@php.net",
					"kbradley1l@yahoo.co.jp",
					"ageorge1m@dion.ne.jp",
					"jford1n@dell.com",
					"glynch1o@fc2.com",
					"jwarren1p@cornell.edu",
					"rgilbert1q@umn.edu",
					"kwilliamson1r@surveymonkey.com",
					"rwagner1s@wunderground.com",
					"pmedina1t@thetimes.co.uk",
					"cmason1u@go.com",
					"rjackson1v@gizmodo.com",
					"lkim1w@hugedomains.com",
					"aharper1x@dailymail.co.uk",
					"jpeters1y@chron.com",
					"rgarrett1z@blogspot.com",
					"tdavis20@51.la",
					"mgarza21@bizjournals.com",
					"eflores22@google.com",
					"lspencer23@jigsy.com",
					"jgraham24@paginegialle.it",
					"imeyer25@fastcompany.com",
					"amedina26@e-recht24.de",
					"hray27@apache.org",
					"abryant28@thetimes.co.uk",
					"achapman29@wiley.com",
					"jporter2a@discovery.com",
					"charris2b@time.com",
					"adavis2c@thetimes.co.uk",
					"jtaylor2d@webs.com",
					"bblack2e@businessweek.com",
					"jkelley2f@symantec.com",
					"ecastillo2g@ezinearticles.com",
					"hgraham2h@bing.com",
					"cfields2i@independent.co.uk",
					"rmason2j@icio.us",
					"aford2k@hud.gov",
					"tcunningham2l@ca.gov",
					"crice2m@state.gov",
					"dhenry2n@redcross.org",
					"pcoleman2o@mysql.com",
					"kwilson2p@eepurl.com",
					"rramos2q@zimbio.com",
					"fhart2r@dmoz.org",
					"bmartinez2s@free.fr",
					"tharper2t@auda.org.au",
					"bfields2u@technorati.com",
					"afuller2v@a8.net",
					"jmeyer2w@wisc.edu",
					"brivera2x@yandex.ru",
					"dlawrence2y@wikia.com",
					"acole2z@mediafire.com",
					"wrivera30@geocities.com",
					"jlane31@usda.gov",
					"jhunt32@pinterest.com",
					"rwells33@list-manage.com",
					"jsanders34@cam.ac.uk",
					"spayne35@princeton.edu",
					"wshaw36@163.com",
					"alynch37@prlog.org",
					"kwallace38@mapy.cz",
					"mwagner39@bbc.co.uk",
					"kreyes3a@ucsd.edu",
					"elong3b@amazon.de",
					"rcooper3c@furl.net",
					"jgreen3d@123-reg.co.uk",
					"amason3e@bizjournals.com",
					"mhawkins3f@123-reg.co.uk",
					"cporter3g@comcast.net",
					"kharper3h@sourceforge.net",
					"wwright3i@arstechnica.com",
					"bprice3j@ifeng.com",
					"crobertson3k@phoca.cz",
					"ebutler3l@msu.edu",
					"cburke3m@parallels.com",
					"ehamilton3n@washingtonpost.com",
					"areed3o@cbc.ca",
					"clane3p@sitemeter.com",
					"dlopez3q@ycombinator.com",
					"asnyder3r@who.int",
					"daustin3s@cornell.edu",
					"sturner3t@boston.com",
					"treynolds3u@yahoo.co.jp",
					"ksullivan3v@sphinn.com",
					"jmorales3w@php.net",
					"wharris3x@newsvine.com",
					"eramirez3y@php.net",
					"bcruz3z@squidoo.com",
					"drichardson40@printfriendly.com",
					"jolson41@berkeley.edu",
					"dowens42@engadget.com",
					"jgutierrez43@msn.com",
					"jfrazier44@meetup.com",
					"dfowler45@google.com.hk",
					"rhernandez46@disqus.com",
					"jcrawford47@ehow.com",
					"bfox48@abc.net.au",
					"mwhite49@nih.gov",
					"lholmes4a@psu.edu",
					"jrobertson4b@discuz.net",
					"jwelch4c@mysql.com",
					"kgarrett4d@de.vu",
					"adavis4e@shop-pro.jp",
					"rgonzales4f@nasa.gov",
					"jjackson4g@newyorker.com",
					"klittle4h@vinaora.com",
					"jortiz4i@springer.com",
					"psnyder4j@cdbaby.com",
					"lellis4k@ebay.co.uk",
					"ahayes4l@webnode.com",
					"mwelch4m@yandex.ru",
					"sward4n@nifty.com",
					"mflores4o@cdc.gov",
					"sjames4p@nationalgeographic.com",
					"ewilliams4q@facebook.com",
					"rholmes4r@squarespace.com",
					"aromero4s@google.com.au",
					"bknight4t@amazon.com",
					"wsullivan4u@discuz.net",
					"rreyes4v@com.com",
					"cpayne4w@amazon.com",
					"jmarshall4x@arstechnica.com",
					"fjacobs4y@delicious.com",
					"nreynolds4z@about.me",
					"jfisher50@github.io",
					"rrivera51@webeden.co.uk",
					"clong52@slashdot.org",
					"egomez53@t-online.de",
					"mfranklin54@hubpages.com",
					"sbishop55@ezinearticles.com",
					"eduncan56@skype.com",
					"rfernandez57@blogtalkradio.com",
					"jkelley58@house.gov",
					"tpowell59@theatlantic.com",
					"jstevens5a@theatlantic.com",
					"jrivera5b@creativecommons.org",
					"bcunningham5c@cnet.com",
					"vwelch5d@soundcloud.com",
					"shenry5e@bbc.co.uk",
					"dfisher5f@fema.gov",
					"nbennett5g@scientificamerican.com",
					"lmartinez5h@deviantart.com",
					"bmoore5i@pagesperso-orange.fr",
					"tbennett5j@forbes.com",
					"ffields5k@hp.com",
					"breid5l@who.int",
					"rnguyen5m@slideshare.net",
					"tpowell5n@stanford.edu",
					"lstephens5o@yahoo.com",
					"bharper5p@apache.org",
					"bboyd5q@bluehost.com",
					"jferguson5r@businessinsider.com",
					"jbrooks5s@over-blog.com",
					"ebrown5t@hatena.ne.jp",
					"jperkins5u@sitemeter.com",
					"wevans5v@nbcnews.com",
					"jjackson5w@eventbrite.com",
					"dhughes5x@free.fr",
					"tlopez5y@hexun.com",
					"kchavez5z@domainmarket.com",
					"ekim60@merriam-webster.com",
					"kmccoy61@fda.gov",
					"jjames62@census.gov",
					"aanderson63@wordpress.org",
					"bhenderson64@cdbaby.com",
					"dferguson65@reuters.com",
					"lcox66@nature.com",
					"agriffin67@yolasite.com",
					"jperry68@surveymonkey.com",
					"bsimpson69@tuttocitta.it",
					"jlynch6a@odnoklassniki.ru",
					"gjames6b@sun.com",
					"cday6c@quantcast.com",
					"pcarr6d@paginegialle.it",
					"awashington6e@myspace.com",
					"pwells6f@example.com",
					"aedwards6g@ihg.com",
					"mjordan6h@dailymotion.com",
					"jelliott6i@canalblog.com",
					"mweaver6j@odnoklassniki.ru",
					"aporter6k@hud.gov",
					"njordan6l@people.com.cn",
					"eschmidt6m@zimbio.com",
					"agibson6n@wp.com",
					"cburns6o@yahoo.co.jp",
					"jbishop6p@abc.net.au",
					"mday6q@nbcnews.com",
					"lwoods6r@gizmodo.com",
					"jthompson6s@usgs.gov",
					"jstewart6t@berkeley.edu",
					"jlewis6u@4shared.com",
					"smartinez6v@unc.edu",
					"pwarren6w@time.com",
					"cmorrison6x@gnu.org",
					"npatterson6y@phpbb.com",
					"emcdonald6z@theglobeandmail.com",
					"jwilliamson70@yahoo.co.jp",
					"carmstrong71@mediafire.com",
					"llane72@earthlink.net",
					"rvasquez73@digg.com",
					"ktorres74@ox.ac.uk",
					"rwhite75@xing.com",
					"bcole76@timesonline.co.uk",
					"aburns77@nhs.uk",
					"elane78@addthis.com",
					"bporter79@mediafire.com",
					"bhughes7a@google.it",
					"rmartinez7b@1und1.de",
					"nalexander7c@w3.org",
					"mjacobs7d@yellowpages.com",
					"jfuller7e@myspace.com",
					"rhoward7f@about.com",
					"pbaker7g@blogs.com",
					"lmorgan7h@indiatimes.com",
					"rhart7i@redcross.org",
					"ahernandez7j@ow.ly",
					"rmiller7k@yellowbook.com",
					"landerson7l@google.cn",
					"jmarshall7m@oracle.com",
					"clane7n@msu.edu",
					"rjackson7o@wix.com",
					"scook7p@home.pl",
					"cmatthews7q@cnn.com",
					"srivera7r@umn.edu",
					"vharper7s@google.it",
					"hbanks7t@patch.com",
					"awillis7u@xrea.com",
					"ckelly7v@edublogs.org",
					"baustin7w@sciencedirect.com",
					"hgrant7x@diigo.com",
					"kmendoza7y@abc.net.au",
					"wlee7z@livejournal.com",
					"pgutierrez80@hostgator.com",
					"eryan81@indiatimes.com",
					"jschmidt82@mediafire.com",
					"wwebb83@microsoft.com",
					"rthomas84@go.com",
					"cbailey85@harvard.edu",
					"candrews86@ezinearticles.com",
					"jbarnes87@google.es",
					"abutler88@ezinearticles.com",
					"gpowell89@theguardian.com",
					"bgomez8a@hhs.gov",
					"sgonzales8b@github.com",
					"mnelson8c@howstuffworks.com",
					"fpayne8d@godaddy.com",
					"jmorales8e@zimbio.com",
					"dknight8f@list-manage.com",
					"rmills8g@studiopress.com",
					"tgrant8h@harvard.edu",
					"wcunningham8i@de.vu",
					"cedwards8j@slate.com",
					"jryan8k@springer.com",
					"dreynolds8l@cam.ac.uk",
					"erogers8m@youtu.be",
					"lthompson8n@clickbank.net",
					"jpeterson8o@prweb.com",
					"tvasquez8p@prweb.com",
					"jyoung8q@cdc.gov",
					"rsimmons8r@ameblo.jp",
					"ecampbell8s@feedburner.com",
					"mpowell8t@i2i.jp",
					"jrose8u@princeton.edu",
					"akennedy8v@indiegogo.com",
					"jhayes8w@live.com",
					"aflores8x@princeton.edu",
					"rwashington8y@people.com.cn",
					"mharper8z@dailymotion.com",
					"jturner90@unblog.fr",
					"jthompson91@flickr.com",
					"ljohnson92@de.vu",
					"rblack93@angelfire.com",
					"aschmidt94@netvibes.com",
					"wkennedy95@github.io",
					"dhudson96@vkontakte.ru",
					"lholmes97@eepurl.com",
					"jmurphy98@4shared.com",
					"sperez99@chronoengine.com",
					"djenkins9a@simplemachines.org",
					"lwatson9b@marriott.com",
					"chanson9c@opera.com",
					"jwilliamson9d@japanpost.jp",
					"bwhite9e@reverbnation.com",
					"rdiaz9f@sciencedirect.com",
					"cgarza9g@shinystat.com",
					"dgreen9h@mapquest.com",
					"mdaniels9i@nasa.gov",
					"tjohnson9j@blogspot.com",
					"dwoods9k@odnoklassniki.ru",
					"mhayes9l@smugmug.com",
					"eturner9m@free.fr",
					"mgray9n@mayoclinic.com",
					"dgarcia9o@wix.com",
					"jortiz9p@nba.com",
					"awarren9q@hubpages.com",
					"vyoung9r@nsw.gov.au",
					"lharper9s@plala.or.jp",
					"pwood9t@naver.com",
					"rcarr9u@squidoo.com",
					"lallen9v@360.cn",
					"agibson9w@tripadvisor.com",
					"banderson9x@fotki.com",
					"rford9y@skype.com",
					"khunt9z@berkeley.edu",
					"mwallacea0@google.it",
					"cmurraya1@usgs.gov",
					"chilla2@deviantart.com",
					"ahamiltona3@moonfruit.com",
					"lgonzalesa4@surveymonkey.com",
					"ameyera5@networkadvertising.org",
					"swarda6@webmd.com",
					"tmorenoa7@google.cn",
					"fjohnsona8@weibo.com",
					"dfergusona9@wp.com",
					"cparkeraa@businessinsider.com",
					"bcruzab@over-blog.com",
					"jcolemanac@artisteer.com",
					"sriveraad@walmart.com",
					"ethompsonae@pagesperso-orange.fr",
					"tdixonaf@smh.com.au",
					"rcolemanag@indiegogo.com",
					"jduncanah@discovery.com",
					"jedwardsai@mediafire.com",
					"hlynchaj@ucla.edu",
					"jmontgomeryak@paginegialle.it",
					"tdanielsal@lycos.com",
					"jsimpsonam@blogger.com",
					"kmccoyan@jiathis.com",
					"jbrownao@sitemeter.com",
					"amedinaap@ovh.net",
					"pcunninghamaq@oaic.gov.au",
					"bhicksar@time.com",
					"crayas@gizmodo.com",
					"ahansenat@disqus.com",
					"mweaverau@theglobeandmail.com",
					"aharveyav@oakley.com",
					"hmillsaw@mapquest.com",
					"tlittleax@nasa.gov",
					"lmarshallay@chron.com",
					"afernandezaz@hhs.gov",
					"hrodriguezb0@mysql.com",
					"lgreenb1@unblog.fr",
					"cfoxb2@godaddy.com",
					"asimpsonb3@senate.gov",
					"wweaverb4@spiegel.de",
					"cblackb5@g.co",
					"gsandersb6@google.fr",
					"srogersb7@unicef.org",
					"bgarciab8@ehow.com",
					"cscottb9@google.ca",
					"mjenkinsba@istockphoto.com",
					"mgarciabb@vkontakte.ru",
					"swalkerbc@oaic.gov.au",
					"eboydbd@plala.or.jp",
					"rwillisbe@toplist.cz",
					"tsmithbf@de.vu",
					"jaustinbg@bluehost.com",
					"hruizbh@xinhuanet.com",
					"hsanchezbi@xing.com",
					"eburkebj@fc2.com",
					"mturnerbk@google.com.br",
					"pporterbl@mediafire.com",
					"jfullerbm@rambler.ru",
					"mkingbn@lycos.com",
					"jfordbo@japanpost.jp",
					"cwatkinsbp@is.gd",
					"tschmidtbq@amazon.de",
					"ereedbr@mapquest.com",
					"fmurphybs@va.gov",
					"hboydbt@princeton.edu",
					"ahernandezbu@instagram.com",
					"sdanielsbv@linkedin.com",
					"mjenkinsbw@wikipedia.org",
					"mbarnesbx@time.com",
					"sfisherby@histats.com",
					"ageorgebz@feedburner.com",
					"sriverac0@free.fr",
					"ahansenc1@livejournal.com",
					"jjacobsc2@addthis.com",
					"dmurrayc3@sbwire.com",
					"rspencerc4@dion.ne.jp",
					"ebishopc5@ycombinator.com",
					"athompsonc6@nsw.gov.au",
					"msanchezc7@1688.com",
					"sfullerc8@ehow.com",
					"bmedinac9@europa.eu",
					"smedinaca@geocities.com",
					"jknightcb@sitemeter.com",
					"hgibsoncc@thetimes.co.uk",
					"tdaycd@flavors.me",
					"adeance@wired.com",
					"elawsoncf@dagondesign.com",
					"cbaileycg@360.cn",
					"aperkinsch@amazonaws.com",
					"wbrooksci@bloomberg.com",
					"jreedcj@youku.com",
					"hfergusonck@php.net",
					"kgraycl@barnesandnoble.com",
					"balvarezcm@reuters.com",
					"acarpentercn@surveymonkey.com",
					"kreynoldsco@bbc.co.uk",
					"clanecp@dailymotion.com",
					"llopezcq@tmall.com",
					"djonescr@studiopress.com",
					"achapmancs@rambler.ru",
					"anicholsct@vinaora.com",
					"efowlercu@mac.com",
					"vcarpentercv@networkadvertising.org",
					"rwalkercw@apache.org",
					"fstephenscx@forbes.com",
					"mromerocy@nhs.uk",
					"nbarnescz@illinois.edu",
					"ggomezd0@ucla.edu",
					"bthomasd1@slate.com",
					"tgarzad2@github.com",
					"walvarezd3@jigsy.com",
					"ewatsond4@slideshare.net",
					"tsnyderd5@scribd.com",
					"sdeand6@bizjournals.com",
					"krobertsd7@wix.com",
					"hwestd8@earthlink.net",
					"crobertsond9@furl.net",
					"kharveyda@dagondesign.com",
					"tromerodb@alibaba.com",
					"bnicholsdc@sourceforge.net",
					"jcooperdd@istockphoto.com",
					"cfoxde@github.io",
					"dcastillodf@blogspot.com",
					"jdixondg@reuters.com",
					"jstanleydh@weather.com",
					"jturnerdi@bigcartel.com",
					"dpiercedj@netvibes.com",
					"hortizdk@harvard.edu",
					"nwoodsdl@vimeo.com",
					"scookdm@earthlink.net",
					"elittledn@twitter.com",
					"bcunninghamdo@foxnews.com",
					"jpaynedp@webs.com",
					"dbakerdq@a8.net",
					"jlopezdr@ocn.ne.jp",
					"nhernandezds@typepad.com",
					"kwarrendt@hugedomains.com",
					"jwatkinsdu@vkontakte.ru",
					"bmurphydv@whitehouse.gov",
					"aelliottdw@github.io",
					"tevansdx@purevolume.com",
					"drogersdy@geocities.com",
					"wlanedz@a8.net",
					"wpricee0@nature.com",
					"thickse1@indiegogo.com",
					"rnicholse2@google.nl",
					"rrogerse3@purevolume.com",
					"mharveye4@networksolutions.com",
					"pcollinse5@jimdo.com",
					"jandrewse6@nhs.uk",
					"dleee7@hubpages.com",
					"mharveye8@youtu.be",
					"mgordone9@symantec.com",
					"sharrisonea@merriam-webster.com",
					"aramirezeb@slideshare.net",
					"rcastilloec@cyberchimps.com",
					"pburnsed@si.edu",
					"dholmesee@goo.ne.jp",
					"jcookef@phoca.cz",
					"bwilliseg@surveymonkey.com",
					"jwilliamseh@hexun.com",
					"lwebbei@tinyurl.com",
					"trichardsej@about.com",
					"jchavezek@drupal.org",
					"mhernandezel@sohu.com",
					"scollinsem@ehow.com",
					"arobertsen@wix.com",
					"challeo@g.co",
					"clewisep@ibm.com",
					"kgonzalezeq@google.com.hk",
					"jsullivaner@bing.com",
					"mmendozaes@examiner.com",
					"bfieldset@thetimes.co.uk",
					"jbarneseu@google.fr",
					"rwoodev@ning.com",
					"abrooksew@home.pl",
					"rwatkinsex@nyu.edu",
					"ahernandezey@umn.edu",
					"pwatsonez@nba.com",
					"pbellf0@pbs.org",
					"bgrantf1@google.com.au",
					"cdiazf2@desdev.cn",
					"srossf3@acquirethisname.com",
					"cmurrayf4@scribd.com",
					"jbrownf5@imgur.com",
					"mcruzf6@vinaora.com",
					"jfernandezf7@sciencedaily.com",
					"sgrayf8@bloglines.com",
					"cturnerf9@ucla.edu",
					"rmartinezfa@opera.com",
					"jmendozafb@va.gov",
					"rscottfc@nih.gov",
					"chamiltonfd@prlog.org",
					"cwallacefe@shinystat.com",
					"hellisff@prlog.org",
					"ehallfg@tumblr.com",
					"amorrisonfh@odnoklassniki.ru",
					"tmorrisfi@themeforest.net",
					"ssimsfj@baidu.com",
					"cwilliamsfk@jugem.jp",
					"jmurrayfl@typepad.com",
					"cwatsonfm@wikimedia.org",
					"jreedfn@reverbnation.com",
					"kwhitefo@usgs.gov",
					"nscottfp@nydailynews.com",
					"jjohnstonfq@archive.org",
					"eporterfr@state.tx.us",
					"rbarnesfs@cbc.ca",
					"mfernandezft@jigsy.com",
					"ileefu@va.gov",
					"dlongfv@shop-pro.jp",
					"sstanleyfw@spotify.com",
					"rmartinfx@webmd.com",
					"smartinfy@livejournal.com",
					"mbishopfz@hhs.gov",
					"tscottg0@gov.uk",
					"rburkeg1@weebly.com",
					"ghendersong2@shop-pro.jp",
					"pmoralesg3@yandex.ru",
					"malvarezg4@elpais.com",
					"jhayesg5@google.com.br",
					"jrichardsong6@yellowbook.com",
					"pwallaceg7@tinyurl.com",
					"jgardnerg8@taobao.com",
					"tbakerg9@engadget.com",
					"creynoldsga@xrea.com",
					"hwalkergb@amazon.de",
					"ksimpsongc@bravesites.com",
					"rwardgd@examiner.com",
					"eramirezge@scientificamerican.com",
					"rstonegf@wiley.com",
					"vbarnesgg@rambler.ru",
					"jgreenegh@pbs.org",
					"jchapmangi@csmonitor.com",
					"sjacobsgj@state.tx.us",
					"jvasquezgk@wordpress.com",
					"hwellsgl@about.com",
					"jharpergm@istockphoto.com",
					"ahernandezgn@unicef.org",
					"jricego@sphinn.com",
					"clittlegp@statcounter.com",
					"tjenkinsgq@paypal.com",
					"jtuckergr@virginia.edu",
					"egarciags@cafepress.com",
					"mevansgt@narod.ru",
					"areedgu@shinystat.com",
					"rfullergv@cnn.com",
					"haustingw@dot.gov",
					"rhuntergx@geocities.com",
					"emartinezgy@tuttocitta.it",
					"kfraziergz@livejournal.com",
					"belliotth0@exblog.jp",
					"shansonh1@rambler.ru",
					"gmurphyh2@cafepress.com",
					"bgriffinh3@soundcloud.com",
					"shenryh4@google.com",
					"agordonh5@sitemeter.com",
					"ehamiltonh6@t.co",
					"rramosh7@eepurl.com",
					"kryanh8@sourceforge.net",
					"lgrayh9@naver.com",
					"breidha@rambler.ru",
					"cfordhb@psu.edu",
					"klawsonhc@prnewswire.com",
					"jpattersonhd@cpanel.net",
					"jrodriguezhe@google.it",
					"mmarshallhf@msu.edu",
					"gnelsonhg@so-net.ne.jp",
					"mthomashh@seesaa.net",
					"pwebbhi@oakley.com",
					"rmorrishj@nps.gov",
					"vmoorehk@mashable.com",
					"flonghl@blogtalkradio.com",
					"wgrayhm@bravesites.com",
					"bmatthewshn@quantcast.com",
					"dgarrettho@opera.com",
					"tcooperhp@tumblr.com",
					"abrookshq@geocities.jp",
					"dmontgomeryhr@nyu.edu",
					"jandersonhs@furl.net",
					"rjohnstonht@webs.com",
					"lharthu@squidoo.com",
					"jleehv@bloglines.com",
					"athompsonhw@1und1.de",
					"jharperhx@go.com",
					"awatsonhy@gov.uk",
					"lthomashz@vinaora.com",
					"rgarciai0@nsw.gov.au",
					"hhayesi1@reuters.com",
					"bbanksi2@squidoo.com",
					"chenryi3@nbcnews.com",
					"jlawrencei4@noaa.gov",
					"dberryi5@newyorker.com",
					"hgilberti6@elegantthemes.com",
					"jbennetti7@wordpress.com",
					"jsullivani8@webeden.co.uk",
					"eburkei9@webmd.com",
					"gparkeria@newyorker.com",
					"hhansenib@mapy.cz",
					"tcarrollic@ucsd.edu",
					"tgrayid@shop-pro.jp",
					"egarzaie@g.co",
					"hparkerif@blogger.com",
					"sshawig@over-blog.com",
					"jbradleyih@cloudflare.com",
					"rwilsonii@ft.com",
					"hgriffinij@163.com",
					"awoodik@printfriendly.com",
					"dstevensil@answers.com",
					"aellisim@ucoz.ru",
					"ccollinsin@rambler.ru",
					"lsandersio@themeforest.net",
					"nperryip@liveinternet.ru",
					"kbanksiq@reference.com",
					"jwatsonir@imageshack.us",
					"eholmesis@symantec.com",
					"lwoodit@gnu.org",
					"sdavisiu@bigcartel.com",
					"pshawiv@pinterest.com",
					"jdanielsiw@weibo.com",
					"iblackix@google.ru",
					"pfrankliniy@apple.com",
					"kgrahamiz@marketwatch.com",
					"rperryj0@blog.com",
					"lryanj1@guardian.co.uk",
					"jwarrenj2@feedburner.com",
					"ehernandezj3@yelp.com",
					"lwoodsj4@cdc.gov",
					"dperkinsj5@java.com",
					"lwestj6@mozilla.com",
					"dsandersj7@dyndns.org",
					"ktaylorj8@yahoo.co.jp",
					"madamsj9@opera.com",
					"erichardsja@bizjournals.com",
					"jmasonjb@umn.edu",
					"bnguyenjc@google.com.br",
					"mwalkerjd@ask.com",
					"hwalkerje@nifty.com",
					"jcunninghamjf@elpais.com",
					"dspencerjg@bloomberg.com",
					"dmoorejh@github.io",
					"ccastilloji@mtv.com",
					"randrewsjj@ucsd.edu",
					"jsandersjk@psu.edu",
					"swalkerjl@nydailynews.com",
					"wbanksjm@prlog.org",
					"btaylorjn@shop-pro.jp",
					"rrodriguezjo@youtube.com",
					"cpetersjp@alibaba.com",
					"tberryjq@cyberchimps.com",
					"cyoungjr@amazonaws.com",
					"rowensjs@histats.com",
					"rpetersjt@tripod.com",
					"dmarshallju@cmu.edu",
					"mhendersonjv@dailymotion.com",
					"lwilsonjw@drupal.org",
					"dedwardsjx@discovery.com",
					"djohnsonjy@cbsnews.com",
					"pburkejz@etsy.com",
					"jmitchellk0@tripadvisor.com",
					"rbradleyk1@forbes.com",
					"jhayesk2@wunderground.com",
					"afosterk3@so-net.ne.jp",
					"fmorgank4@cam.ac.uk",
					"dellisk5@shareasale.com",
					"preedk6@ucsd.edu",
					"jaustink7@bloglines.com",
					"srobertsonk8@nationalgeographic.com",
					"rdayk9@baidu.com",
					"nriveraka@fastcompany.com",
					"dharrisonkb@woothemes.com",
					"vweaverkc@pagesperso-orange.fr",
					"dmillskd@twitter.com",
					"jmartinke@blogspot.com",
					"brobertsonkf@arizona.edu",
					"rmontgomerykg@hubpages.com",
					"jfoxkh@geocities.jp",
					"sperkinski@globo.com",
					"whernandezkj@msn.com",
					"eelliottkk@ovh.net",
					"gmorrisonkl@telegraph.co.uk",
					"aboydkm@cocolog-nifty.com",
					"cfosterkn@dropbox.com",
					"jkellyko@tiny.cc",
					"jwilliskp@dagondesign.com",
					"jstevenskq@geocities.jp",
					"mmasonkr@craigslist.org",
					"mpowellks@acquirethisname.com",
					"bmartinkt@java.com",
					"kbaileyku@newsvine.com",
					"bharperkv@php.net",
					"skennedykw@bluehost.com",
					"rkingkx@topsy.com",
					"jmendozaky@nbcnews.com",
					"asmithkz@auda.org.au",
					"hpiercel0@tinypic.com",
					"staylorl1@chronoengine.com",
					"jduncanl2@godaddy.com",
					"krosel3@google.it",
					"nhernandezl4@example.com",
					"smartinl5@businessinsider.com",
					"lmontgomeryl6@i2i.jp",
					"jcoxl7@nsw.gov.au",
					"awellsl8@marriott.com",
					"wcrawfordl9@eventbrite.com",
					"kcolemanla@state.gov",
					"mgrahamlb@nasa.gov",
					"clawsonlc@acquirethisname.com",
					"sbutlerld@technorati.com",
					"ejacksonle@angelfire.com",
					"kcolemanlf@squidoo.com",
					"drobertsonlg@reference.com",
					"mhawkinslh@newyorker.com",
					"sjordanli@europa.eu",
					"aallenlj@whitehouse.gov",
					"hpowelllk@dedecms.com",
					"jfieldsll@topsy.com",
					"vreedlm@cdbaby.com",
					"jbarnesln@mashable.com",
					"dwagnerlo@com.com",
					"dharveylp@icq.com",
					"pjenkinslq@nydailynews.com",
					"arichardsonlr@godaddy.com",
					"srobertsls@jigsy.com",
					"earmstronglt@opera.com",
					"dknightlu@people.com.cn",
					"dpattersonlv@livejournal.com",
					"vtaylorlw@wordpress.org",
					"mgonzalezlx@mapy.cz",
					"dtaylorly@hexun.com",
					"pbaileylz@usda.gov",
					"dbanksm0@ameblo.jp",
					"dduncanm1@instagram.com",
					"rlopezm2@wiley.com",
					"jgarzam3@phoca.cz",
					"ssandersm4@imdb.com",
					"bmyersm5@geocities.jp",
					"mhughesm6@marketwatch.com",
					"tlawrencem7@drupal.org",
					"amccoym8@digg.com",
					"mkennedym9@devhub.com",
					"enicholsma@sina.com.cn",
					"jsimmonsmb@about.com",
					"krichardsmc@intel.com",
					"emartinezmd@naver.com",
					"rcarpenterme@mit.edu",
					"awoodsmf@thetimes.co.uk",
					"wharpermg@apache.org",
					"bcruzmh@bluehost.com",
					"chowardmi@cam.ac.uk",
					"ewagnermj@whitehouse.gov",
					"fleemk@comsenz.com",
					"dmendozaml@usda.gov",
					"pcampbellmm@chicagotribune.com",
					"rbishopmn@storify.com",
					"jfowlermo@dagondesign.com",
					"sthompsonmp@webeden.co.uk",
					"atuckermq@tripadvisor.com",
					"jmyersmr@spotify.com",
					"jbakerms@google.fr",
					"astewartmt@guardian.co.uk",
					"kreidmu@census.gov",
					"jparkermv@latimes.com",
					"djenkinsmw@economist.com",
					"hthomasmx@mac.com",
					"hburtonmy@ehow.com",
					"wcarrmz@cpanel.net",
					"aellisn0@fastcompany.com",
					"pfranklinn1@so-net.ne.jp",
					"rholmesn2@cdc.gov",
					"llanen3@fc2.com",
					"shansenn4@cbc.ca",
					"erileyn5@slideshare.net",
					"cwestn6@weibo.com",
					"amedinan7@va.gov",
					"mharpern8@tinyurl.com",
					"jhudsonn9@unc.edu",
					"drogersna@livejournal.com",
					"kbradleynb@drupal.org",
					"abaileync@twitter.com",
					"drobertsonnd@kickstarter.com",
					"shudsonne@ovh.net",
					"agrahamnf@walmart.com",
					"hthompsonng@blog.com",
					"sthompsonnh@princeton.edu",
					"jmorrisonni@goo.gl",
					"rhowellnj@msu.edu",
					"agomeznk@hao123.com",
					"chamiltonnl@cbc.ca",
					"skingnm@4shared.com",
					"wallennn@reference.com",
					"dlawsonno@reddit.com",
					"jrosenp@symantec.com",
					"jstonenq@barnesandnoble.com",
					"tcarrollnr@clickbank.net",
					"bpricens@godaddy.com",
					"dfishernt@telegraph.co.uk",
					"pgarzanu@earthlink.net",
					"rfowlernv@jigsy.com",
					"jmatthewsnw@ifeng.com",
					"jwillisnx@skyrock.com",
					"awalkerny@a8.net",
					"dandrewsnz@privacy.gov.au",
					"mmeyero0@surveymonkey.com",
					"swagnero1@flavors.me",
					"rphillipso2@themeforest.net",
					"smooreo3@cbc.ca",
					"djameso4@google.co.jp",
					"lcartero5@baidu.com",
					"alyncho6@berkeley.edu",
					"prosso7@yellowbook.com",
					"mkennedyo8@multiply.com",
					"jlittleo9@chronoengine.com",
					"ljohnstonoa@discovery.com",
					"mfergusonob@eventbrite.com",
					"whenryoc@ning.com",
					"dcoleod@godaddy.com",
					"wbishopoe@addthis.com",
					"triceof@dagondesign.com",
					"jfrazierog@examiner.com",
					"awatkinsoh@microsoft.com",
					"rwrightoi@themeforest.net",
					"amoralesoj@jugem.jp",
					"dlawrenceok@bandcamp.com",
					"ahenryol@php.net",
					"ntuckerom@taobao.com",
					"tjenkinson@moonfruit.com",
					"gparkeroo@cyberchimps.com",
					"ahansenop@springer.com",
					"dfernandezoq@yahoo.com",
					"asimsor@nytimes.com",
					"mrobinsonos@berkeley.edu",
					"jcookot@1688.com",
					"kpalmerou@miibeian.gov.cn",
					"areyesov@accuweather.com",
					"jcrawfordow@ibm.com",
					"cadamsox@auda.org.au",
					"pellisoy@linkedin.com",
					"gstephensoz@imdb.com",
					"dnguyenp0@microsoft.com",
					"rweaverp1@skyrock.com",
					"bandersonp2@jugem.jp",
					"jolsonp3@quantcast.com",
					"hwallacep4@java.com",
					"ccrawfordp5@harvard.edu",
					"jricep6@arizona.edu",
					"jalvarezp7@fema.gov",
					"wwrightp8@amazon.co.jp",
					"nreynoldsp9@taobao.com",
					"mgonzalespa@plala.or.jp",
					"dgonzalezpb@domainmarket.com",
					"ecolemanpc@princeton.edu",
					"charperpd@geocities.com",
					"jmartinezpe@imgur.com",
					"ksimspf@miitbeian.gov.cn",
					"agarzapg@irs.gov",
					"mstephensph@livejournal.com",
					"jalexanderpi@wikipedia.org",
					"erobertsonpj@wisc.edu",
					"jgreenepk@bravesites.com",
					"cscottpl@fc2.com",
					"ddiazpm@oakley.com",
					"chickspn@blogs.com",
					"dgreenepo@godaddy.com",
					"pramirezpp@seattletimes.com",
					"mbryantpq@devhub.com",
					"aevanspr@hexun.com",
					"kmartinps@wix.com",
					"csullivanpt@ca.gov",
					"aandersonpu@amazon.de",
					"trodriguezpv@list-manage.com",
					"showellpw@google.ru",
					"pharperpx@multiply.com",
					"rowenspy@deliciousdays.com",
					"jweaverpz@yahoo.co.jp",
					"crayq0@biblegateway.com",
					"jcoleq1@webmd.com",
					"bfordq2@wsj.com",
					"nruizq3@reference.com",
					"awheelerq4@adobe.com",
					"jrichardsq5@usatoday.com",
					"rcunninghamq6@bluehost.com",
					"jfernandezq7@imdb.com",
					"ssmithq8@ebay.co.uk",
					"mwilliamsonq9@tiny.cc",
					"sbellqa@thetimes.co.uk",
					"ndeanqb@shutterfly.com",
					"vcastilloqc@geocities.com",
					"rbarnesqd@pen.io",
					"mpayneqe@wisc.edu",
					"drussellqf@craigslist.org",
					"cmendozaqg@hhs.gov",
					"hcooperqh@sbwire.com",
					"lknightqi@hatena.ne.jp",
					"dharrisqj@macromedia.com",
					"bwrightqk@gmpg.org",
					"enicholsql@sfgate.com",
					"rstanleyqm@technorati.com",
					"crobertsqn@ovh.net",
					"hmasonqo@nationalgeographic.com",
					"mcarrqp@moonfruit.com",
					"lreynoldsqq@comcast.net",
					"scarrollqr@netvibes.com",
					"barnoldqs@google.nl",
					"jdiazqt@amazon.com",
					"csmithqu@163.com",
					"csimsqv@biglobe.ne.jp",
					"mjordanqw@marketwatch.com",
					"efordqx@eventbrite.com",
					"pdeanqy@t-online.de",
					"thallqz@creativecommons.org",
					"bmurrayr0@usgs.gov",
					"rreyesr1@odnoklassniki.ru",
					"nreyesr2@mediafire.com",
					"fberryr3@wikia.com",
					"crobertsonr4@businesswire.com",
					"tjacksonr5@homestead.com",
					"dpayner6@mit.edu",
					"mbennettr7@usatoday.com",
					"kmurphyr8@unicef.org",
					"mjamesr9@aboutads.info",
					"tburnsra@simplemachines.org",
					"dgarciarb@tripadvisor.com",
					"scastillorc@elegantthemes.com",
					"wfoxrd@bing.com",
					"mtorresre@mapy.cz",
					"ljohnstonrf@accuweather.com",
					"sfieldsrg@amazon.de",
					"ncunninghamrh@tripadvisor.com",
					"jvasquezri@constantcontact.com",
					"lrobertsrj@cbc.ca",
					"amorenork@themeforest.net",
					"pgeorgerl@alibaba.com",
					"amillerrm@shutterfly.com",
					"nfullerrn@wsj.com",
					"rmontgomeryro@list-manage.com",
					"lrogersrp@harvard.edu",
					"lstewartrq@mayoclinic.com",
					"knicholsrr@usnews.com",
				};
		}
		#endregion
	}
}
