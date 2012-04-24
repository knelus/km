-- phpMyAdmin SQL Dump
-- version 3.2.0.1
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Apr 23, 2012 at 08:40 PM
-- Server version: 5.1.36
-- PHP Version: 5.3.0

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `km`
--

-- --------------------------------------------------------

--
-- Table structure for table `documents`
--

CREATE TABLE IF NOT EXISTS `documents` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `file` varchar(250) NOT NULL,
  `title` varchar(50) NOT NULL,
  `user` int(11) NOT NULL,
  `description` text NOT NULL,
  `location` varchar(250) NOT NULL,
  `tags` varchar(250) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=5 ;

--
-- Dumping data for table `documents`
--


-- --------------------------------------------------------

--
-- Table structure for table `interests`
--

CREATE TABLE IF NOT EXISTS `interests` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tag` varchar(50) NOT NULL,
  `user` int(11) NOT NULL,
  `score` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=22 ;

--
-- Dumping data for table `interests`
--

INSERT INTO `interests` (`id`, `tag`, `user`, `score`) VALUES
(18, 'leuke', 1, 1),
(17, 'een', 1, 4),
(16, 'is', 1, 3),
(15, 'dit', 1, 3),
(14, 'test', 1, 5),
(13, 'huis', 1, 1),
(12, 'voorbeeld', 1, 4);

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE IF NOT EXISTS `user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  `hash` varchar(50) NOT NULL,
  `fullName` varchar(250) NOT NULL,
  `email` varchar(250) NOT NULL,
  `registrationDate` int(11) NOT NULL,
  `lastLoginDate` int(11) NOT NULL,
  `profileText` text NOT NULL,
  `administrator` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=4 ;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`id`, `username`, `password`, `hash`, `fullName`, `email`, `registrationDate`, `lastLoginDate`, `profileText`, `administrator`) VALUES
(1, 'mark', 'b47722ef7bd28d0f46ae24ec83a4f1d4', '1_ecffea94a7fc4ecb615026ba8376e2af', 'groenteman', 'Mark Johan Smit', 0, 1335213584, 'haha een test\r\nleuk mijn profiel\r\nGeen idee wat er mee te doen', 1),
(3, 'mark.smit', 'b47722ef7bd28d0f46ae24ec83a4f1d4', '', '', '', 1335184923, 0, '', 0);
