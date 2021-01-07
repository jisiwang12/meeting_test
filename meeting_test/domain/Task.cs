using System;

namespace meeting_test.domain
{
    public class Task
    {
        private String faqiren;
        private String time;
        private String shenheren;
        private String id;
        private String serial;
        private String zherenren;
        private String content;
        private String gonghao;
        private String sqtime;
        private String status;
        private String bu;
        private String timeformat;
        private String subject;

        public string Faqiren
        {
            get => faqiren;
            set => faqiren = value;
        }

        public string Time
        {
            get => time;
            set => time = value;
        }

        public string Shenheren
        {
            get => shenheren;
            set => shenheren = value;
        }

        public string Id
        {
            get => id;
            set => id = value;
        }

        public string Serial
        {
            get => serial;
            set => serial = value;
        }

        public string Zherenren
        {
            get => zherenren;
            set => zherenren = value;
        }

        public string Content
        {
            get => content;
            set => content = value;
        }

        public string Gonghao
        {
            get => gonghao;
            set => gonghao = value;
        }

        public string Sqtime
        {
            get => sqtime;
            set => sqtime = value;
        }

        public string Status
        {
            get => status;
            set => status = value;
        }

        public string Bu
        {
            get => bu;
            set => bu = value;
        }

        public string Timeformat
        {
            get => timeformat;
            set => timeformat = value;
        }

        public string Subject
        {
            get => subject;
            set => subject = value;
        }


        public override string ToString()
        {
            return $"{nameof(faqiren)}: {faqiren}, {nameof(time)}: {time}, {nameof(shenheren)}: {shenheren}, {nameof(id)}: {id}, {nameof(serial)}: {serial}, {nameof(zherenren)}: {zherenren}, {nameof(content)}: {content}, {nameof(gonghao)}: {gonghao}, {nameof(sqtime)}: {sqtime}, {nameof(status)}: {status}, {nameof(bu)}: {bu}, {nameof(timeformat)}: {timeformat}, {nameof(subject)}: {subject}, {nameof(Faqiren)}: {Faqiren}, {nameof(Time)}: {Time}, {nameof(Shenheren)}: {Shenheren}, {nameof(Id)}: {Id}, {nameof(Serial)}: {Serial}, {nameof(Zherenren)}: {Zherenren}, {nameof(Content)}: {Content}, {nameof(Gonghao)}: {Gonghao}, {nameof(Sqtime)}: {Sqtime}, {nameof(Status)}: {Status}, {nameof(Bu)}: {Bu}, {nameof(Timeformat)}: {Timeformat}, {nameof(Subject)}: {Subject}";
        }
    }
}