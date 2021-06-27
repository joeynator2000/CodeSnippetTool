-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 27, 2021 at 08:16 PM
-- Server version: 10.4.17-MariaDB
-- PHP Version: 7.3.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `snippet_db`
--

-- --------------------------------------------------------

--
-- Table structure for table `snippets`
--

CREATE TABLE `snippets` (
  `id` int(6) NOT NULL,
  `name` varchar(255) DEFAULT NULL,
  `snippet_text` text DEFAULT NULL,
  `lang` varchar(255) DEFAULT NULL,
  `favourite` int(6) DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  `HotKey` varchar(255) DEFAULT NULL,
  `date_added` datetime DEFAULT NULL,
  `last_copied` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `snippets`
--

INSERT INTO `snippets` (`id`, `name`, `snippet_text`, `lang`, `favourite`, `description`, `HotKey`, `date_added`, `last_copied`) VALUES
(3, 'StringCheck', ' // Main Method\r\n    public static void Main(string[] args)\r\n    {\r\n        string s1 = \"GeeksforGeeks\";\r\n      \r\n        // or declare String s2.Empty;\r\n        string s2 = \"\"; \r\n  \r\n        string s3 = null;\r\n  \r\n        // for String value Geeks, return true\r\n        bool b1 = string.IsNullOrEmpty(s1);\r\n  \r\n        // For String value Empty or \"\", return true\r\n        bool b2 = string.IsNullOrEmpty(s2);\r\n  \r\n        // For String value null, return true\r\n        bool b3 = string.IsNullOrEmpty(s3);\r\n  \r\n        Console.WriteLine(b1);\r\n        Console.WriteLine(b2);\r\n        Console.WriteLine(b3);\r\n    }', ' C#', 1, 'Checks if string is empty', 'D1+Alt', '2021-06-23 13:13:44', '2021-06-25 17:57:32'),
(5, 'LoopJava', 'for (int i = 0; i < 5; i++) {\r\n  System.out.println(i);\r\n}', ' Java', 0, 'Basic for loop', 'y+Alt', '2021-06-23 15:13:44', '2021-06-26 17:19:01'),
(7, 'BasicSwitch', 'using System;\r\n\r\npublic class Example\r\n{\r\n   public static void Main()\r\n   {\r\n      int caseSwitch = 1;\r\n\r\n      switch (caseSwitch)\r\n      {\r\n          case 1:\r\n              Console.WriteLine(\"Case 1\");\r\n              break;\r\n          case 2:\r\n              Console.WriteLine(\"Case 2\");\r\n              break;\r\n          default:\r\n              Console.WriteLine(\"Default case\");\r\n              break;\r\n      }\r\n   }\r\n}\r\n// The example displays the following output:\r\n//       Case 1', 'C#', 0, 'Basic switch statement for c#', 'o+Alt', '2021-06-24 12:11:44', '2021-06-27 20:14:21'),
(14, 'ParsingToInt', '	public static void main(String args[]){\r\n		int x =Integer.parseInt(\"9\");\r\n		double c = Double.parseDouble(\"5\");\r\n		int b = Integer.parseInt(\"444\",16);\r\n\r\n		System.out.println(x);\r\n		System.out.println(c);\r\n		System.out.println(b);\r\n	}', ' Java', 1, 'Parse String to Integer', 't+Alt', '2021-06-25 23:13:42', '2021-06-26 17:27:40'),
(15, 'StringReplacerJs', 'function replaceString(oldS, newS, fullS) {\r\n// Replaces oldS with newS in the string fullS\r\n   for (var i = 0; i < fullS.length; i++) {\r\n      if (fullS.substring(i, i + oldS.length) == oldS) {\r\n         fullS = fullS.substring(0, i) + newS + fullS.substring(i + oldS.length, fullS.length);\r\n      }\r\n   }\r\n   return fullS;\r\n}\r\n\r\nreplaceString(\"World\", \"Web\", \"Brave New World\");', 'Javascript', 1, 'Replace string in javascript', 'k+Shift', '2021-06-25 16:24:46', '2021-06-27 20:06:24'),
(19, 'JsSlice', 'var str1 = \'The morning is upon us.\';\r\nvar str2 = str1.slice(4,-2);\r\n\r\nconsole.log(str2); // OUTPUT: morning is upon u', ' JavaScript', 1, 'Slice string in javascript', 'D6+Shift', '2021-06-27 20:04:18', '2021-06-27 20:04:28');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `snippets`
--
ALTER TABLE `snippets`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `snippets`
--
ALTER TABLE `snippets`
  MODIFY `id` int(6) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
