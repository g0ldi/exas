﻿using System;
using System.Collections.Generic;
using ExAs.Utils;
using ExAs.Utils.SystemExtensions;
using ToText;

namespace ExAs.Results
{
    public class ObjectAssertionResult
    {
        public readonly bool succeeded;
        public readonly string log;
        public readonly string expectation;

        public ObjectAssertionResult(bool succeeded, string log, string expectation)
        {
            this.succeeded = succeeded;
            this.log = log;
            this.expectation = expectation;
        }

        public string PrintLog()
        {
            string[] logLines = log.SplitLines();
            string[] expectationLines = expectation.SplitLines();
            int longestLogLine = logLines.MaxOrDefault(s => s.Length);
            IReadOnlyList<string> resultingLogLines = logLines.Map(expectationLines, 
                                                                   (al, el) => al.FillUpWithSpacesToLength(longestLogLine).Add(" ").Add(el));
            return string.Join(Environment.NewLine, resultingLogLines);
        }

        public override string ToString()
        {
            return this.ToText(x => x.succeeded,
                               x => x.log,
                               x => x.expectation);
        }
    }
}